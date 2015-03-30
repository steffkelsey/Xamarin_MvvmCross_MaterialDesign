using Android.App;
using Android.OS;
using Android.Transitions;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.FullFragging.Fragments;
using Cirrious.MvvmCross.ViewModels;
using MvxMaterial.Core.ViewModels;
using MvxMaterial.Presenters;
using MvxMaterial.Views;
using MvxMaterial.Views.Fragments;

namespace MvxMaterial
{
    [Activity(Label = "MvxMaterial.DroidFullFrag"
        , Theme = "@style/Theme.MaterialDemo")]
    public class MainActivity : BaseCachingFragmentAcivity, IFragmentHost
    {
        protected override void OnCreate(Bundle bundle)
        {
            //Mvx.Trace("MainActivity:OnCreate");
            base.OnCreate(bundle);

            registerFragments(bundle);

            SetContentView(Resource.Layout.container);

            var mainViewModel = (MainViewModel)this.ViewModel;

            if (bundle == null)
            {
                if (mainViewModel.IsLoggedIn)
                    mainViewModel.ShowHomeCommand.Execute(null);
                else
                    mainViewModel.ShowLoginCommand.Execute(null);
            }
        }

        private void registerFragments(Bundle bundle)
        {
            RegisterFragment<LoginView, LoginViewModel>(typeof(LoginView).Name, bundle);
            RegisterFragment<MailListView, MailListViewModel>(typeof(MailListView).Name, bundle);
            RegisterFragment<SettingsView, SettingsViewModel>(typeof(SettingsView).Name, bundle);
            RegisterFragment<WriteMessageView, WriteMessageViewModel>(typeof(WriteMessageView).Name, bundle);
        }

        public void RegisterFragment<TFragment, TViewModel>(string tag, Bundle args, IMvxViewModel viewModel = null)
            where TFragment : IMvxFragmentView where TViewModel : IMvxViewModel
        {
            var customPresenter = Mvx.Resolve<IFragmentsPresenter>();
            customPresenter.RegisterViewModelAtHost<TViewModel>(this);
            RegisterFragment<TFragment, TViewModel>(tag);
        }

        public bool Show(MvxViewModelRequest request, Bundle bundle)
        {
            if (request.ViewModelType == typeof(LoginViewModel))
            {
                ShowFragment(typeof(LoginView).Name, Resource.Id.contentFrame, bundle, false);
                return true;
            }
            if (request.ViewModelType == typeof(MailListViewModel))
            {
                ShowFragment(typeof(MailListView).Name, Resource.Id.contentFrame, bundle, false);
                return true;
            }
            if (request.ViewModelType == typeof(SettingsViewModel))
            {
                ShowFragment(typeof(SettingsView).Name, Resource.Id.contentFrame, bundle);
                return true;
            }

            if (request.ViewModelType == typeof(WriteMessageViewModel))
            {
                ShowFragment(typeof(WriteMessageView).Name, Resource.Id.contentFrame, bundle);
                return true;
            }
            return false;
        }

        public override void OnBackPressed()
        {
            //Mvx.Trace("MainActivity:OnBackPressed");
            // check what fragment is currently on top
            //Mvx.Trace("BackStackEntryCount = " + FragmentManager.BackStackEntryCount);
            if (FragmentManager.BackStackEntryCount == 0)
            {
                MoveTaskToBack(true);
                return;
            }
            CloseCurrentFragment(Resource.Id.contentFrame);
        }

        public override void OnBeforeFragmentRemove(string tag, FragmentTransaction transaction) 
        {
            var fragInfo = GetFragInfoByTag(tag);
            var transitionInflater = TransitionInflater.From(this);
            if (tag == typeof(MailListView).Name)
            {
                fragInfo.CachedFragment.ExitTransition = transitionInflater.InflateTransition(Resource.Transition.long_fade);
            }
        }

        public override void OnFragmentChanging(string tag, FragmentTransaction transaction) 
        {
            var fragInfo = GetFragInfoByTag(tag);
            var transitionInflater = TransitionInflater.From(this);
            // make sure the transitions is correct for this tag
            if (tag == typeof(SettingsView).Name)
            {
                fragInfo.CachedFragment.EnterTransition = transitionInflater.InflateTransition(Resource.Transition.slide_right);
                fragInfo.CachedFragment.ExitTransition = transitionInflater.InflateTransition(Resource.Transition.slide_right);
                fragInfo.CachedFragment.ReenterTransition = transitionInflater.InflateTransition(Resource.Transition.slide_right);
                fragInfo.CachedFragment.ReturnTransition = transitionInflater.InflateTransition(Resource.Transition.slide_right);
            }
            else if (tag == typeof(MailListView).Name)
            {
                //fragInfo.CachedFragment.EnterTransition = null;
                //fragInfo.CachedFragment.ExitTransition = null;
                //fragInfo.CachedFragment.ReturnTransition = null;
                //fragInfo.CachedFragment.ReenterTransition = null;
                //fragInfo.CachedFragment.AllowEnterTransitionOverlap = false;
            }
            else if (tag == typeof(LoginView).Name)
            {
                fragInfo.CachedFragment.ExitTransition = transitionInflater.InflateTransition(Resource.Transition.slide_left);
            }
            else if (tag == typeof(WriteMessageView).Name)
            {
                fragInfo.CachedFragment.EnterTransition = transitionInflater.InflateTransition(Resource.Transition.slide_bottom);
                //fragInfo.CachedFragment.ExitTransition = transitionInflater.InflateTransition(Resource.Transition.slide_bottom);
            }
        }
    }
}