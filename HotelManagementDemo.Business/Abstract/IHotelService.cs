using HotelManagementDemo.Core.Utilities.Results;
using HotelManagementDemo.Entities.Concrete;
using System.Collections.Generic;

namespace HotelManagementDemo.Business.Abstract
{
    public interface IHotelService
    {
        /// <summary>
        /// Get single hotel
        /// </summary>
        /// <returns>Returns Hotel, Status, Message</returns>
        public IDataResult<Hotel> GetById(int id);
 

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


        /// <summary>
        /// Update hotel
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns Status and Message of Update Operation</returns>
        public IResult Update(Hotel entity);


        /// <summary>
        /// Delete hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>Returns Status and Message of Delete Operation</returns>
        public IResult Delete(Hotel hotel);
    }
}
