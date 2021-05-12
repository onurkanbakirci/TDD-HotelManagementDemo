using HotelManagementDemo.WPFUI.Models.Concrete.Dtos;
using HotelManagementDemo.WPFUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDemo.WPFUI.Services.Abstract
{
    public interface IAuthService
    {
        public void Login(LoginViewViewModel loginViewModel, UserForLoginDto userForLoginDto);
    }
}
