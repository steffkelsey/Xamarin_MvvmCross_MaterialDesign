using Cirrious.MvvmCross.ViewModels;
using MvxMaterial.Core.ViewModels.Base;

namespace MvxMaterial.Core.ViewModels
{
    public class WriteMessageViewModel : BaseViewModel
    {
        public WriteMessageViewModel()
        {
            Title = "Write a Message";
        }

        public IMvxCommand GoBackCommand
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }

        public IMvxCommand ShowSettingsCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<SettingsViewModel>());
            }
        }
    }
}