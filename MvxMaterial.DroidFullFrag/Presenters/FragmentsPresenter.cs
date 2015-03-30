using Android.OS;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;

namespace MvxMaterial.Presenters
{
    public class FragmentsPresenter : MvxAndroidViewPresenter, IFragmentsPresenter
    {
        public const string ViewModelRequestBundleKey = "__mvxViewModelRequest";

        private readonly Dictionary<Type, IFragmentHost> _dictionary = new Dictionary<Type, IFragmentHost>();
        private IMvxNavigationSerializer _serializer;

        protected IMvxNavigationSerializer Serializer
        {
            get
            {
                if (_serializer != null)
                    return _serializer;

                _serializer = Mvx.Resolve<IMvxNavigationSerializer>();
                return _serializer;
            }
        }

        /// <summary>
        /// Register your ViewModel to be presented at a IFragmentHost. Backingstore for this is a 
        /// Dictionary, hence you can only have a ViewModel registered at one IFragmentHost at a time.
        /// Just call this method whenever you need to change the host.
        /// </summary>
        /// <typeparam name="TViewModel">Type of the ViewModel to present</typeparam>
        /// <param name="host">Which IFragmentHost (Activity) to present it at</param>
        public void RegisterViewModelAtHost<TViewModel>(IFragmentHost host) 
            where TViewModel : IMvxViewModel
        {
            if (host == null)
            {
                Mvx.Warning("You passed a null IFragmentHost, removing the registration instead");
                UnRegisterViewModelAtHost<TViewModel>();
            }
                
            _dictionary[typeof (TViewModel)] = host;
        }

        public void UnRegisterViewModelAtHost<TViewModel>()
            where TViewModel : IMvxViewModel
        {
            _dictionary.Remove(typeof (TViewModel));
        }

        public override void Show(MvxViewModelRequest request)
        {
            var bundle = new Bundle();
            var serializedRequest = Serializer.Serializer.SerializeObject(request);
            bundle.PutString(ViewModelRequestBundleKey, serializedRequest);

            IFragmentHost host;
            if (_dictionary.TryGetValue(request.ViewModelType, out host))
            {
                if (host.Show(request, bundle))
                    return;
            }
            
            base.Show(request);
        }

        public override void Close(IMvxViewModel viewModel)
        {
            IFragmentHost host;
            var vType = viewModel.GetType();
            if (_dictionary.TryGetValue(vType, out host))
            {
                if (host.Close(viewModel))
                    return;
            }

            base.Close(viewModel);
        }
    }
}