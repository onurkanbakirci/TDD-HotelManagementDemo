using HotelManagementDemo.WPFUI.Models.Concrete.Dtos;
using HotelManagementDemo.WPFUI.Services.Abstract;
using HotelManagementDemo.WPFUI.Services.API;
using HotelManagementDemo.WPFUI.ViewModels;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelManagementDemo.WPFUI.Services
{
    public class AuthManager : IAuthService
    { 
        public async void Login(LoginViewViewModel loginViewModel, UserForLoginDto userForLoginDto)
        {

                loginViewModel.IsSpin = "Visible";

                string json = JsonConvert.SerializeObject(userForLoginDto);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await ConnectionBase.GetInstance().PostAsync(Endpoints.LOGIN, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    loginViewModel.User.Status = true;
                }
                else
                {
                    loginViewModel.User.Status = false;
                }

                var responseBody = await response.Content.ReadAsStringAsync();
                loginViewModel.User.Message = JsonConvert.DeserializeObject<UserForLoginDto>(responseBody).Message;
            
        }
    }
}
