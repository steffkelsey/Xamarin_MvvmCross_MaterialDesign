using Cirrious.MvvmCross.ViewModels;
using MvxMaterial.Core.ViewModels;

namespace MvxMaterial.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            this.RegisterAppStart<MainViewModel>();
        }
    }
}