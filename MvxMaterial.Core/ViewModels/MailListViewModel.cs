using Cirrious.MvvmCross.ViewModels;
using MvxMaterial.Core.ViewModels.Base;

namespace MvxMaterial.Core.ViewModels
{
    public class MailListViewModel : BaseViewModel
    {
        public MailListViewModel()
        {
            Title = "All Messages";
        }

        public IMvxCommand GoBackCommand
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }

        public IMvxCommand ShowWriteCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<WriteMessageViewModel>());
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