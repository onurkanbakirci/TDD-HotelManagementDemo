using HotelManagementDemo.Core.DataAccess;
using HotelManagementDemo.Entities.Concrete;

namespace HotelManagementDemo.DataAccess.Abstract
{
    public interface IUserDal : IRepositoryBase<User>
    {
    }
}
