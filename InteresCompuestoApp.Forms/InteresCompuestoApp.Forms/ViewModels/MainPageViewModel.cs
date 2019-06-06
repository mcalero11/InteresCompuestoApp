using InteresCompuestoApp.Forms.Helpers;
using InteresCompuestoApp.Forms.ViewModels.Base;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace InteresCompuestoApp.Forms.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Commands
        public ICommand CalculateCommand { get; set; }
        #endregion
        #region Fields
        private bool _isVisible;
        private decimal _montoField;
        private decimal _capitalField;
        private decimal _interesField;
        private decimal _periodosField;
        private double _resultField;
        #endregion
        #region Properties
        public bool IsVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value); }
        }
        public decimal MontoProperty
        {
            get { return _montoField; }
            set { SetProperty(ref _montoField, value); }
        }
        public decimal CapitalProperty
        {
            get { return _capitalField; }
            set { SetProperty(ref _capitalField, value); }
        }
        public decimal InteresProperty
        {
            get { return _interesField; }
            set { SetProperty(ref _interesField, value); }
        }
        public decimal PeriodosProperty
        {
            get { return _periodosField; }
            set { SetProperty(ref _periodosField, value); }
        }
        public double ResultProperty
        {
            get { return _resultField; }
            set { SetProperty(ref _resultField, value); }
        }
        #endregion
        #region Constructors
        public MainPageViewModel()
        {
            CalculateCommand = new Command(CalculateOperation);
        }

        #endregion
        #region Methods
        private void CalculateOperation()
        {
            IsVisible = true;
            var _base = (1 + InteresProperty).ToDouble();
            var potencia = PeriodosProperty.ToDouble();

            ResultProperty = Math.Pow(_base, potencia);
            ResultProperty *= CapitalProperty.ToDouble();
        }
        #endregion
    }
}
