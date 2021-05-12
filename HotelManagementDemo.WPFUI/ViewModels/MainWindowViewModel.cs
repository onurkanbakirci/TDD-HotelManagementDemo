using HotelManagementDemo.WPFUI.Services.Abstract;
using System.ComponentModel;

namespace HotelManagementDemo.WPFUI.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged,IViewModel
    {

        public IViewModel _currentPageViewModel;
        public IViewModel CurrentViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                _currentPageViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }


        public MainWindowViewModel(IAuthService authService)
        {
            CurrentViewModel = new LoginViewViewModel(authService);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
