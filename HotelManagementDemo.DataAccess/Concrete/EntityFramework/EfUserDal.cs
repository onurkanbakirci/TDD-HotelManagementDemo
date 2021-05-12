using HotelManagementDemo.Core.DataAccess.EntityFramework;
using HotelManagementDemo.DataAccess.Abstract;
using HotelManagementDemo.DataAccess.Concrete.EntityFramework.Contexts;
using HotelManagementDemo.Entities.Concrete;

namespace HotelManagementDemo.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfRepositoryBase<HotelManagementDemoContext,User>, IUserDal
    {

    }
}
