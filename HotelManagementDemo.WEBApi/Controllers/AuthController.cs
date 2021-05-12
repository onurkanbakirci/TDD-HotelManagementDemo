using HotelManagementDemo.Business.Abstract;
using HotelManagementDemo.Core.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementDemo.WEBApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        public IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        /// <summary>
        /// Login for user
        /// </summary>
        /// <param name="userForLoginDto"></param>
        /// <returns>Returns user, status, message</returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserForLoginDto userForLoginDto)
        {
            var result = _authService.Login(userForLoginDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
