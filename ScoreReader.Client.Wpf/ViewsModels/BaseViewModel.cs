using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ScoreReader.Client.Wpf.Common;

namespace ScoreReader.Client.Wpf.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged, IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetValue<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(property, value))
                return false;

            property = value;
            OnPropertyChanged(propertyName);

            return true;
        }
    }
}
