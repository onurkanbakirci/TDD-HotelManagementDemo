using HotelManagementDemo.Business.Abstract;
using HotelManagementDemo.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementDemo.WEBApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        public IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns>Returns List of Users, operation status, operation message</returns>
        [HttpGet("getAll")]
        public IActionResult GetAllUsers()
        {
            var result = _userService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        /// <summary>
        /// Get List of User By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns list of user, operation success, operation message</returns>
        [HttpGet("getById/{id}")]
        public IActionResult GetAllUsersById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        /// <summary>
        /// Get List of User By Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Returns list of user, operation success, operation message</returns>
        [HttpGet("getByName/{name}")]
        public IActionResult GetAllUsersByName(string name)
        {
            var result = _userService.GetByName(name);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns status and update operation message</returns>
        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns status and delete operation message</returns>
        [HttpDelete]
        public IActionResult DeleteUser(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
