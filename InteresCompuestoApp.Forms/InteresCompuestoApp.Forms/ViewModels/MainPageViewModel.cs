using InteresCompuestoApp.Forms.Helpers;
using InteresCompuestoApp.Forms.Models;
using InteresCompuestoApp.Forms.Models.Mocks;
using InteresCompuestoApp.Forms.Validations;
using InteresCompuestoApp.Forms.Validations.Base;
using InteresCompuestoApp.Forms.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace InteresCompuestoApp.Forms.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Commands
        public ICommand CalculateCommand => new Command(CalculateOperation);
        public ICommand ValidateMontoCommand => new Command(() => validateMonto());
        public ICommand ValidateCapitalCommand => new Command(() => validateCapital());
        public ICommand ValidateInteresCommand => new Command(() => validateInteres());
        public ICommand ValidatePeriodosCommand => new Command(() => validateInteres());
        #endregion

        #region Fields
        private bool _isVisible;
        private decimal _montoField;
        private decimal _capitalField;
        private decimal _interesField;
        private decimal _periodosField;
        private string _resultField;

        private ValidatableObject<string> _monto;
        private ValidatableObject<string> _capital;
        private ValidatableObject<string> _interes;
        private ValidatableObject<string> _periodos;

        private ObservableCollection<Operation> _operations;
        private Operation _selectedItem;

        private bool _montoEnabled;
        private bool _capitalEnabled;
        private bool _interesEnabled;
        private bool _periodosEnabled;

        #endregion

        #region Properties
        public ValidatableObject<string> Monto
        {
            get { return _monto; }
            set { SetProperty(ref _monto, value); }
        }
        public ValidatableObject<string> Capital
        {
            get { return _capital; }
            set { SetProperty(ref _capital, value); }
        }
        public ValidatableObject<string> Interes
        {
            get { return _interes; }
            set { SetProperty(ref _interes, value); }
        }
        public ValidatableObject<string> Periodos
        {
            get { return _periodos; }
            set { SetProperty(ref _periodos, value); }
        }
        public bool IsVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value); }
        }
        public string ResultProperty
        {
            get { return _resultField; }
            set { SetProperty(ref _resultField, value); }
        }
        public ObservableCollection<Operation> Operations
        {
            get { return _operations; }
            set { SetProperty(ref _operations, value); }
        }
        public Operation SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
                OperationChanged();
            }
        }
        public bool MontoEnabled
        {
            get { return _montoEnabled; }
            set { SetProperty(ref _montoEnabled, value); }
        }
        public bool CapitalEnabled
        {
            get { return _capitalEnabled; }
            set { SetProperty(ref _capitalEnabled, value); }
        }
        public bool InteresEnabled
        {
            get { return _interesEnabled; }
            set { SetProperty(ref _interesEnabled, value); }
        }
        public bool PeriodosEnabled
        {
            get { return _periodosEnabled; }
            set { SetProperty(ref _periodosEnabled, value); }
        }
        #endregion

        #region Constructors
        public MainPageViewModel()
        {
            Monto = new ValidatableObject<string>();
            Capital = new ValidatableObject<string>();
            Interes = new ValidatableObject<string>();
            Periodos = new ValidatableObject<string>();
            IsVisible = false;
            Operations = new ObservableCollection<Operation>(MockOperations.GetOperationList());
            SelectedItem = Operations[0];
            addValidations();

            
        }

        #endregion
        #region Methods
        private void addValidations()
        {
            _monto.Validations.Add(new IsNullOrEmptyRule<string>("El campo monto no debe estar vacío."));
            _monto.Validations.Add(new IsDecimalField<string>("El campo monto debe ser numérico."));
            _capital.Validations.Add(new IsNullOrEmptyRule<string>("El campo capital no debe estar vacío."));
            _capital.Validations.Add(new IsDecimalField<string>("El campo capital debe ser numérico."));
            _interes.Validations.Add(new IsNullOrEmptyRule<string>("El campo interés no debe estar vacío."));
            _interes.Validations.Add(new IsDecimalField<string>("El campo interés debe ser numérico."));
            _periodos.Validations.Add(new IsNullOrEmptyRule<string>("El campo periodos no debe estar vacío."));
            _periodos.Validations.Add(new IsIntegerField<string>("El campo periodos debe ser numérico sin signo."));
        }

        private bool validate()
        {
            bool isMontoValid = validateMonto();
            bool isCapitalValid = validateCapital();
            bool isInteresValid = validateInteres();
            bool isPeriodosValid = validatePeriodos();

            return isMontoValid && isCapitalValid && isInteresValid && isPeriodosValid;
        }

        #region Validations
        private bool validateMonto()
        {
            if (!MontoEnabled) return true;
            return _monto.Validate();
        }

        private bool validateCapital()
        {
            if (!CapitalEnabled) return true;
            return _capital.Validate();
        }

        private bool validateInteres()
        {
            if (!InteresEnabled) return true;
            return _interes.Validate();
        }

        private bool validatePeriodos()
        {
            if (!PeriodosEnabled) return true;
            return _periodos.Validate();
        }

        #endregion

        private void OperationChanged()
        {
            if (SelectedItem == (Operations[0] ?? new Operation()))
            {
                MontoEnabled = false;
                CapitalEnabled = true;
                InteresEnabled = true;
                PeriodosEnabled = true;
            }
            else if (SelectedItem == (Operations[1] ?? new Operation()))
            {
                MontoEnabled = true;
                CapitalEnabled = false;
                InteresEnabled = true;
                PeriodosEnabled = true;
            }
            else if (SelectedItem == (Operations[2] ?? new Operation()))
            {
                MontoEnabled = true;
                CapitalEnabled = true;
                InteresEnabled = false;
                PeriodosEnabled = true;
            }
            else if (SelectedItem == (Operations[3] ?? new Operation()))
            {
                MontoEnabled = true;
                CapitalEnabled = true;
                InteresEnabled = true;
                PeriodosEnabled = false;
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "No se ha seleccionado ninguna operación a realizar", "Ok");
            }

        }

        private void CalculateOperation()
        {
            if (!validate()) return;

            _montoField = decimal.Parse(Monto.Value ?? "0");
            _capitalField = decimal.Parse(Capital.Value ?? "0");
            _interesField = decimal.Parse(Interes.Value ?? "0") / 100;
            _periodosField = decimal.Parse(Periodos.Value ?? "0");

            if (SelectedItem == (Operations[0] ?? new Operation()))
            {
                calcularMonto();
            }
            else if (SelectedItem == (Operations[1] ?? new Operation()))
            {
                calcularCapital();
            }
            else if (SelectedItem == (Operations[2] ?? new Operation()))
            {
                calcularInteres();
            }
            else if (SelectedItem == (Operations[3] ?? new Operation()))
            {
                calcularPeriodos();
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "No se ha seleccionado ninguna operación a realizar", "Ok");
            }

            IsVisible = true;

        }

        #region Operaciones
        private void calcularMonto()
        {
            var result = _capitalField.ToDouble() * Math.Pow((1 + _interesField).ToDouble(),_periodosField.ToDouble());

            ResultProperty = result.ToString();
        }
        private void calcularCapital()
        {
            var result = _montoField.ToDouble() / Math.Pow((1 + _interesField.ToDouble()), _periodosField.ToDouble());

            ResultProperty = result.ToString();
        }
        private void calcularInteres()
        {
            var result = Math.Pow((_montoField/_capitalField).ToDouble(),(1/_periodosField.ToDouble()));

            var percentage = (result - 1) * 100;

            ResultProperty = percentage.ToString("N") + "%";
        }
        private void calcularPeriodos()
        {
            var result = Math.Log((_montoField / _capitalField).ToDouble()) / Math.Log(1 + _interesField.ToDouble());
            /*
            var year = (int)Math.Truncate(result);

            var month = (result - year) / 12;

            var day = month - (int)Math.Truncate(result) / 30;
            */
            ResultProperty = result.ToString() + " años";
        }

        #endregion

        #endregion
    }
}
