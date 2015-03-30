using Cirrious.MvvmCross.ViewModels;
using MvxMaterial.Core.ViewModels.Base;
using System.Collections.Generic;

namespace MvxMaterial.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private bool _isLoggedIn = false;
        public bool IsLoggedIn
        {
            get
            {
                return _isLoggedIn;
            }
            set
            {
                _isLoggedIn = value;
                RaisePropertyChanged(() => IsLoggedIn);
            }
        }

        public IMvxCommand ShowHomeCommand
        {
            get
            {
                var presentationBundle = new MvxBundle(new Dictionary<string, string> { { "NavigationMode", "ClearStack" } });
                return new MvxCommand(() => ShowViewModel<MailListViewModel>());
            }
        }

        public IMvxCommand ShowLoginCommand
        {
            get
            {
                var presentationBundle = new MvxBundle(new Dictionary<string, string> { { "NavigationMode", "ClearStack" } });
                return new MvxCommand(() => ShowViewModel<LoginViewModel>());
            }
        }
    }
}
