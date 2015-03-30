using Cirrious.MvvmCross.Droid.FullFragging.Presenter;
using Cirrious.MvvmCross.ViewModels;

namespace MvxMaterial.Presenters
{
    public interface IFragmentHost : IMvxFragmentHost
    {
        bool Close(IMvxViewModel viewModel);
    }
}