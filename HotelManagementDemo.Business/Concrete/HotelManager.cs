using HotelManagementDemo.Business.Abstract;
using HotelManagementDemo.Business.Constants;
using HotelManagementDemo.Core.Utilities.Results;
using HotelManagementDemo.DataAccess.Abstract;
using HotelManagementDemo.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace HotelManagementDemo.Business.Concrete
{
    public class HotelManager : IHotelService
    {
        IHotelDal _hotelDal;
        public HotelManager(IHotelDal hotelDal)
        {
            _hotelDal = hotelDal;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IDataResult<List<Hotel>> GetList()
        {
            return new SuccessDataResult<List<Hotel>>(_hotelDal.GetList());
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IDataResult<List<Hotel>> GetByCity(string city)
        {
            return new SuccessDataResult<List<Hotel>>(_hotelDal.GetList().Where(x => x.City == city).ToList());
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IDataResult<List<Hotel>> GetByState(string state)
        {
            return new SuccessDataResult<List<Hotel>>(_hotelDal.GetList().Where(x => x.State == state).ToList());
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IResult Add(Hotel entity)
        {
            _hotelDal.Add(entity);
            return new SuccessResult(Messages.HotelAdded);
        }

        
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IDataResult<Hotel> GetById(int id)
        {
            return new SuccessDataResult<Hotel>(_hotelDal.Get(x=>x.Id == id));
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IResult Update(Hotel entity)
        {
            try
            {
                _hotelDal.Update(entity);
                return new SuccessResult(Messages.HotelUpdated);
            }
            catch
            {
                return new ErrorResult(Messages.HotelUpdateError);
            }
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IResult Delete(Hotel entity)
        {
            try
            {
                _hotelDal.Delete(entity);
                return new SuccessResult(Messages.HotelDeleted);
            }
            catch
            {
                return new ErrorResult(Messages.HotelDeleteError);
            }
        }
    }
}
