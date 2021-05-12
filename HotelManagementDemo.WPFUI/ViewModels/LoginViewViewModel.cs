using GalaSoft.MvvmLight.Command;
using HotelManagementDemo.WPFUI.Models.Concrete.Dtos;
using HotelManagementDemo.WPFUI.Services.Abstract;
using System.ComponentModel;
using System.Windows.Input;

namespace HotelManagementDemo.WPFUI.ViewModels
{
    public class LoginViewViewModel : INotifyPropertyChanged,IViewModel
    {

        public IAuthService _authService;

        public string _isSpin = "Hidden";
        public string IsSpin
        {
            get
            {
                return _isSpin;
            }
            set
            {
                _isSpin = value;
                OnPropertyChanged(nameof(IsSpin));
            }
        }

        public UserForLoginDto _user;
        public UserForLoginDto User
        {
            get { return _user; }
            set { _user = value; }
        }
        public LoginViewViewModel(IAuthService authService)
        {
            _user = new UserForLoginDto();
            _authService = authService;
        }

        public RelayCommand<UserForLoginDto> _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (new RelayCommand<UserForLoginDto>((loginDto) => {
                        _authService.Login(this, loginDto);
                    }
                ));
            }
            private set { } 
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
