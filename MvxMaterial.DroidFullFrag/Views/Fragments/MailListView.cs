using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.FullFragging.Fragments;
using MvxMaterial.Activities;
using MvxMaterial.Core.ViewModels;

namespace MvxMaterial.Views.Fragments
{
    public class MailListView : MvxFragment<MailListViewModel>
    {
        private DrawerLayout _drawerLayout;
        private ActionBarDrawerToggle _actionBarDrawerToggle;
        private View _view;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetHasOptionsMenu(true);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //Mvx.Trace("MailListView:OnCreateView");
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var viewModel = this.ViewModel;
            _view = this.BindingInflate(Resource.Layout.mail_list, null);
            
            // get the toolbar from the fragment layout
            Toolbar toolbar = (Toolbar)_view.FindViewById(Resource.Id.ToolBar);
            // make the toolbar into the actionbar
            var activity = (MvxActionBarActivity)this.Activity;
            activity.SetSupportActionBar(toolbar);
            activity.SetTitle(Resource.String.mail_list_title);

            _drawerLayout = (DrawerLayout)_view.FindViewById(Resource.Id.drawer_layout);
            //drawerLayout.SetStatusBarBackgroundColor(Resource.Color.dark_orange);
            _actionBarDrawerToggle = new ActionBarDrawerToggle(
                this.Activity,
                _drawerLayout,
                Resource.String.drawer_open,
                Resource.String.drawer_close);

            _drawerLayout.SetDrawerListener(_actionBarDrawerToggle);

            return _view;
        }


        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            //Mvx.Trace("MailListView:OnCreateOptionsMenu");
            //inflater.Inflate(Resource.Menu.main, menu);
        }


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Mvx.Trace("MainListView:OnOptionsItemSelected item = " + item.ToString());
            //Mvx.Trace("itemId = " + item.ItemId);
            //Mvx.Trace("Android.Resource.Id.Home = " + Android.Resource.Id.Home);
            if (item != null && item.ItemId == Android.Resource.Id.Home)
            {
                if (_drawerLayout.IsDrawerOpen(3))
                {
                    _drawerLayout.CloseDrawer(3);
                }
                else
                {
                    _drawerLayout.OpenDrawer(3);
                }
            }
            return base.OnOptionsItemSelected(item);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            _actionBarDrawerToggle.SyncState();
        }
    }
}