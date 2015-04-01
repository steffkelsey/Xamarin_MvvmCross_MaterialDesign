// !MvxFragmentsPresenter.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

// This is a slight mod of !MvxFragmentsPresenter.cs. I needed to change this to support a different
// version of IFragmentHost that give support to the Android Back Button

namespace MvxMaterial.Presenters
{
    public interface IFragmentsPresenter
    {
        void RegisterViewModelAtHost<TViewModel>(IFragmentHost host) where TViewModel : Cirrious.MvvmCross.ViewModels.IMvxViewModel;
        void UnRegisterViewModelAtHost<TViewModel>() where TViewModel : Cirrious.MvvmCross.ViewModels.IMvxViewModel;
    }
}