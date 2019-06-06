using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace InteresCompuestoApp.Forms.ViewModels.Base
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region Fields
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation;
        public Page MainPage;
        private bool isBusy;
        #endregion

        #region Properties
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        #endregion

        #region Constructors
        public BaseViewModel()
        {
            //Navigation = Application.Current.MainPage.Navigation;
            MainPage = Application.Current.MainPage;
        }
        #endregion

        #region Methods
        protected void OnProperty([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProperty<T>(ref T backinfiel, T value, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backinfiel, value))
            {
                return;
            }
            backinfiel = value;
            OnProperty(propertyName);
        }
        #endregion
    }
}
