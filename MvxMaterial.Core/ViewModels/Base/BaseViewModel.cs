using Cirrious.MvvmCross.ViewModels;

namespace MvxMaterial.Core.ViewModels.Base
{
    public class BaseViewModel : MvxViewModel
    {
        private string _title = string.Empty;
        public string Title
        {
            get { 
                return this._title; 
            }
            set
            {
                this._title = value; 
                this.RaisePropertyChanged(() => this.Title); 
            }
        }
    }
}