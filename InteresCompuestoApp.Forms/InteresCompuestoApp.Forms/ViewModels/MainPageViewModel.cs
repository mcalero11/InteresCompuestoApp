using InteresCompuestoApp.Forms.Helpers;
using InteresCompuestoApp.Forms.Validations;
using InteresCompuestoApp.Forms.Validations.Base;
using InteresCompuestoApp.Forms.ViewModels.Base;
using System;
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

        public ValidatableObject<string> Monto
        {
            get { return _monto; }
            set { SetProperty(ref _monto, value); }
        }

        private ValidatableObject<string> _capital;

        public ValidatableObject<string> Capital
        {
            get { return _capital; }
            set { SetProperty(ref _capital, value); }
        }

        private ValidatableObject<string> _interes;

        public ValidatableObject<string> Interes
        {
            get { return _interes; }
            set { SetProperty(ref _interes, value); }
        }

        private ValidatableObject<string> _periodos;

        public ValidatableObject<string> Periodos
        {
            get { return _periodos; }
            set { SetProperty(ref _periodos, value); }
        }


        #endregion
        #region Properties
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
        #endregion
        #region Constructors
        public MainPageViewModel()
        {
            Monto = new ValidatableObject<string>();
            Capital = new ValidatableObject<string>();
            Interes = new ValidatableObject<string>();
            Periodos = new ValidatableObject<string>();
            IsVisible = false;
            addValidations();

        }

        #endregion
        #region Methods
        private void addValidations()
        {
            _monto.Validations.Add(new IsNullOrEmptyRule<string>("El campo monto no debe estar vacío."));
            _capital.Validations.Add(new IsNullOrEmptyRule<string>("El campo capital no debe estar vacío."));
            _interes.Validations.Add(new IsNullOrEmptyRule<string>("El campo interés no debe estar vacío."));
            _periodos.Validations.Add(new IsNullOrEmptyRule<string>("El campo periodos no debe estar vacío."));
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
            return _monto.Validate();
        }

        private bool validateCapital()
        {
            return _capital.Validate();
        }

        private bool validateInteres()
        {
            return _interes.Validate();
        }

        private bool validatePeriodos()
        {
            return _periodos.Validate();
        }

        #endregion


        private void CalculateOperation()
        {
            if (!validate()) return;

            if (!decimal.TryParse(Monto.Value,out _montoField))
            {
                Application.Current.MainPage.DisplayAlert("Cuidado","Monto debe ingresarse en un formato numérico válido", "Ok");
                return;
            }
            if (!decimal.TryParse(Capital.Value,out _capitalField))
            {
                Application.Current.MainPage.DisplayAlert("Cuidado","Capital debe ingresarse en un formato numérico válido", "Ok");
                return;
            }
            if (!decimal.TryParse(Interes.Value,out _interesField))
            {
                Application.Current.MainPage.DisplayAlert("Cuidado","Interes debe ingresarse en un formato numérico válido", "Ok");
                return;
            }
            if (!decimal.TryParse(Periodos.Value,out _periodosField))
            {
                Application.Current.MainPage.DisplayAlert("Cuidado","Periodos debe ingresarse en un formato numérico válido", "Ok");
                return;
            }

            IsVisible = true;



            var _base = (1 + _interesField).ToDouble();
            var potencia = _periodosField.ToDouble();

            ResultProperty = (Math.Pow(_base, potencia) * _capitalField.ToDouble()).ToString();
        }
        #endregion
    }
}
