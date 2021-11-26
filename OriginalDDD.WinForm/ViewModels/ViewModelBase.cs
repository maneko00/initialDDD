using System;
using System.ComponentModel;

namespace OriginalDDD.WinForm.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field,
            T value, string property_name)
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property_name));
            }

            return true;
        }

        public virtual DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
