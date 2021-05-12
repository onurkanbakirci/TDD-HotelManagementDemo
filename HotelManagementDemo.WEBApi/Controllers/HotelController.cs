using HotelManagementDemo.Business.Abstract;
using HotelManagementDemo.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementDemo.WEBApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : Controller
    {
        public IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }


        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns>Returns List of Hotels, operation status, operation message</returns>
        [HttpGet("getAll")]
        public IActionResult GetAllHotels()
        {
            var result = _hotelService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        /// <summary>
        /// Get List of Hotels By State
        /// </summary>
        /// <param name="state"></param>
        /// <returns>Returns list of hotels, operation success, operation message</returns>
        [HttpGet("getByState/{state}")]
        public IActionResult GetAllHotels(string state)
        {
            var result = _hotelService.GetByState(state);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        /// <summary>
        /// Get List of Hotels By City
        /// </summary>
        /// <param name="city"></param>
        /// <returns>Returns list of hotels, operation success, operation message</returns>
        [HttpGet("getByCity/{city}")]
        public IActionResult GetAllHotelsByCity(string city)
        {
            var result = _hotelService.GetByCity(city);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        /// <summary>
        /// Delet hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>Returns status and update operation message</returns>
        [HttpPut]
        public IActionResult UpdateHotel(Hotel hotel)
        {
            var result = _hotelService.Update(hotel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        /// <summary>
        /// Delete hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>Returns status and delete operation message</returns>
        [HttpDelete]
        public IActionResult DeleteHotel(Hotel hotel)
        {
            var result = _hotelService.Delete(hotel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
