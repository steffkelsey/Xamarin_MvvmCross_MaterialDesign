using Cirrious.MvvmCross.ViewModels;
using MvxMaterial.Core.ViewModels.Base;

namespace MvxMaterial.Core.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public SettingsViewModel()
        {
            Title = "Settings";
        }

        public IMvxCommand GoBackCommand
        {
            get 
            {
                return new MvxCommand(() => Close(this)); 
            }
        }
    }
}