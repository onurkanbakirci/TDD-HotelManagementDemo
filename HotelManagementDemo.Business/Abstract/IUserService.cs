using HotelManagementDemo.Core.Utilities.Results;
using HotelManagementDemo.Entities.Concrete;
using System.Collections.Generic;

namespace HotelManagementDemo.Business.Abstract
{
    public interface IUserService
    {
        /// <summary>
        /// Get single user
        /// </summary>
        /// <returns>Returns User, Status, Message</returns>
        public IDataResult<User> GetById(int id);


        /// <summary>
        /// Get single user
        /// </summary>
        /// <returns>Returns User, Status, Message</returns>
        public IDataResult<User> GetByUserName(string username);


        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns>Returns List of Users, Status, Message</returns>
        public IDataResult<List<User>> GetList();


        /// <summary>
        /// Get user list by name
        /// </summary>
        /// <returns>Returns List of Users, Status, Message</returns>
        public IDataResult<List<User>> GetByName(string name);


        /// <summary>
        /// Add new User
        /// </summary>
        /// <param name="entity">new user entity</param>
        /// <returns>Returns Status and Message of Add Operation</returns>
        public IResult Add(User entity);


        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns Status and Message of Update Operation</returns>
        public IResult Update(User entity);


        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns Status and Message of Delete Operation</returns>
        public IResult Delete(User entity);
    }
}
