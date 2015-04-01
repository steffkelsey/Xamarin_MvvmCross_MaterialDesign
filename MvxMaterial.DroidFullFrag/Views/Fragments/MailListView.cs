using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.FullFragging.Fragments;
using MvxMaterial.Activities;
using MvxMaterial.Core.ViewModels;

namespace MvxMaterial.Views.Fragments
{
    public class MailListView : MvxFragment<MailListViewModel>
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var viewModel = this.ViewModel;
            var view = this.BindingInflate(Resource.Layout.mail_list, null);
            
            // get the toolbar from the fragment layout
            Toolbar toolbar = (Toolbar)view.FindViewById(Resource.Id.ToolBar);
            
            //for crate home button
            var activity = (MvxActionBarActivity)this.Activity;
            activity.SetSupportActionBar(toolbar);
            activity.SetTitle(Resource.String.mail_list_title);

            return view;
        }
    }
}