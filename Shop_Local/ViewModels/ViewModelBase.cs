using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Shop_Local.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }

        #region Extension Methods

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null, Action callback = null)
        {
            if (Equals(storage, value)) return false;

            storage = value;
            callback?.Invoke();
            RaisePropertyChanged(propertyName);

            return true;
        }

        #endregion

        #region Methods

        protected bool InvalidateText(string value, Regex regex)
        {
            return !regex.IsMatch(value ?? string.Empty);
        }

        #endregion
    }
}
