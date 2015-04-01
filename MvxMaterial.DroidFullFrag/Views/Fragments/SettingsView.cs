using Android.Animation;
using Android.App;
using Android.OS;
using Android.Views;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.FullFragging.Fragments;
using MvxMaterial.Core.ViewModels;

namespace MvxMaterial.Views.Fragments
{
    public class SettingsView : MvxFragment<SettingsViewModel>
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            //Mvx.Trace("SettingsView:OnCreate");
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //Mvx.Trace("SettingsView:OnCreateView");
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.settings, null);
        }

        public override void OnResume()
        {
            //Mvx.Trace("SettingsView:OnResume");
            base.OnResume();
        }

        public override void OnPause()
        {
            //Mvx.Trace("SettingsView:OnPause");
            base.OnPause();
        }

        public override void OnStart()
        {
            //Mvx.Trace("SettingsView:OnStart");
            base.OnStart();
        }

        public override void OnStop()
        {
            //Mvx.Trace("SettingsView:OnStop");
            base.OnStop();
        }

        public override void OnAttach(Activity activity)
        {
            //Mvx.Trace("SettingsView:OnAttach");
            base.OnAttach(activity);
        }

        public override void OnDetach()
        {
            //Mvx.Trace("SettingsView:OnDetach");
            base.OnDetach();
        }

        public override Animator OnCreateAnimator(FragmentTransit transit, bool enter, int nextAnim)
        {
            //Mvx.Trace("SettingsView:OnCreateAnimator, transit = " + transit.ToString() +", enter = " + enter +", nextAnim = " + nextAnim);
            //if (EnterTransition != null)
            //   Mvx.Trace("enterTransition = " + EnterTransition.GetType().Name);
            return base.OnCreateAnimator(transit, enter, nextAnim);
        }
    }
}