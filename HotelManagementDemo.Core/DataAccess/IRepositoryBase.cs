using HotelManagementDemo.Core.Utilities.Results;
using HotelManagementDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HotelManagementDemo.Core.DataAccess
{
    public interface IRepositoryBase<T> where T:class,IEntity,new()
    {
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
