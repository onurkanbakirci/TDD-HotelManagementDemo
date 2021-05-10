using HotelManagementDemo.Business.Abstract;
using HotelManagementDemo.Business.Constants;
using HotelManagementDemo.Core.Utilities.Results;
using HotelManagementDemo.DataAccess.Abstract;
using HotelManagementDemo.Entities.Concrete;
using System.Collections.Generic;

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
            return new SuccessDataResult<List<Hotel>>(_hotelDal.GetList(x=>x.City == city));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IDataResult<List<Hotel>> GetByState(string state)
        {
            return new SuccessDataResult<List<Hotel>>(_hotelDal.GetList(x => x.State == state));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IResult Add(Hotel entity)
        {
            _hotelDal.Add(entity);
            return new SuccessResult(Messages.HotelAdded);
        }
    }
}
