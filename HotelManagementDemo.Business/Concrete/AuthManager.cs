using HotelManagementDemo.Business.Abstract;
using HotelManagementDemo.Business.Constants;
using HotelManagementDemo.Core.Entities.Dtos;
using HotelManagementDemo.Core.Utilities.Results;
using HotelManagementDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDemo.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        public IUserService _userService;
        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }
        public IResult Login(UserForLoginDto userForLoginDto)
        {
            var user = _userService.GetByUserName(userForLoginDto.UserName);
            if(user.Data.Password == userForLoginDto.Password)
            {
                return new SuccessDataResult<User>(user.Data, Messages.LoginSuccess);
            }
            return new ErrorResult(Messages.LoginError);
        }
    }
}
