using HotelManagementDemo.Business.Abstract;
using HotelManagementDemo.Business.Constants;
using HotelManagementDemo.Core.Utilities.Results;
using HotelManagementDemo.DataAccess.Abstract;
using HotelManagementDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelManagementDemo.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IResult Add(User entity)
        {
            try
            {
                _userDal.Add(entity);
                return new SuccessResult(Messages.UserAdded);
            }
            catch 
            {
                return new ErrorResult(Messages.UserAddError);
            }
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IResult Delete(User entity)
        {
            try
            {
                _userDal.Delete(entity);
                return new SuccessResult(Messages.UserDeleted);
            }
            catch 
            {
                return new ErrorResult(Messages.UserDeleteError);
            }
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.Id == id));
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public IDataResult<List<User>> GetByName(string name)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetList().Where(x => x.FirstName == name).ToList());
        }

        public IDataResult<User> GetByUserName(string username)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.UserName == username));
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IDataResult<List<User>> GetList()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetList());
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IResult Update(User entity)
        {
            try
            {
                _userDal.Update(entity);
                return new SuccessResult(Messages.UserUpdated);
            }
            catch
            {
                return new ErrorResult(Messages.UserUpdateError);
            }
        }
    }
}
