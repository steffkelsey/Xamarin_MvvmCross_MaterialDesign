using Android.Content;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.ViewModels;
using MvxMaterial.Core;
using MvxMaterial.Presenters;
using System.Collections.Generic;
using System.Reflection;

namespace MvxMaterial
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) 
            : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var customPresenter = new FragmentsPresenter();
            Mvx.RegisterSingleton<IFragmentsPresenter>(customPresenter);
            return customPresenter;
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override IList<Assembly> AndroidViewAssemblies
        {
            get
            {
                var assemblies = base.AndroidViewAssemblies;
                assemblies.Add(typeof(Android.Support.V7.Widget.Toolbar).Assembly);
                assemblies.Add(typeof(Android.Support.V4.Widget.DrawerLayout).Assembly);
                return assemblies;
            }
        }
    }
}