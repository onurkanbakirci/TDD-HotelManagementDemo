using HotelManagementDemo.Core.Utilities.Results;
using HotelManagementDemo.Entities.Concrete;
using System.Collections.Generic;

namespace HotelManagementDemo.Business.Abstract
{
    public interface IHotelService
    {
        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns>Returns List of Hotels, Status, Message</returns>
        public IDataResult<List<Hotel>> GetList();

        /// <summary>
        /// Get All Hotels By City Name
        /// </summary>
        /// <param name="city">city of hotel name</param>
        /// <returns>Returns List of Hotels, Status, Message</returns>
        public IDataResult<List<Hotel>> GetByCity(string city);

        /// <summary>
        /// Get All Hotels By State Name
        /// </summary>
        /// <param name="state">state of hotel name</param>
        /// <returns>Returns List of Hotels, Status, Message</returns>
        public IDataResult<List<Hotel>> GetByState(string state);

        /// <summary>
        /// Add new Hotel
        /// </summary>
        /// <param name="entity">new hotel entity</param>
        /// <returns>Returns Status and Message of Add Operation</returns>
        public IResult Add(Hotel entity);
    }
}
