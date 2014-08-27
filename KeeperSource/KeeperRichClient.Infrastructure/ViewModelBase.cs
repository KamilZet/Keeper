using System.ComponentModel;

namespace KeeperRichClient.Infrastructure
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName){
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));}

    }
}
