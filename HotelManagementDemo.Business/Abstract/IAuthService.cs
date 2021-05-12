using HotelManagementDemo.Core.Entities.Dtos;
using HotelManagementDemo.Core.Utilities.Results;
using HotelManagementDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDemo.Business.Abstract
{
    public interface IAuthService
    {
        IResult Login(UserForLoginDto userForLoginDto); 
    }
}
