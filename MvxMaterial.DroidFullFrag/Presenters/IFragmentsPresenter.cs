namespace MvxMaterial.Presenters
{
    public interface IFragmentsPresenter
    {
        void RegisterViewModelAtHost<TViewModel>(IFragmentHost host) where TViewModel : Cirrious.MvvmCross.ViewModels.IMvxViewModel;
        void UnRegisterViewModelAtHost<TViewModel>() where TViewModel : Cirrious.MvvmCross.ViewModels.IMvxViewModel;
    }
}