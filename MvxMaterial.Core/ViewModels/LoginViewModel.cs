using Cirrious.MvvmCross.ViewModels;
using MvxMaterial.Core.ViewModels.Base;
using System.Collections.Generic;

namespace MvxMaterial.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            Title = "Login";
        }

        public IMvxCommand GoBackCommand
        {
            get
            {
                return new MvxCommand(() => Close(this));
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
    }
}