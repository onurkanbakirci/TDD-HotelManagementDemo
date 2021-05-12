using HotelManagementDemo.Core.Utilities.Results;
using HotelManagementDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HotelManagementDemo.Core.DataAccess
{
    public interface IRepositoryBase<T> where T:class,IEntity,new()
    {
        /// <summary>
        /// Get single data. If there is filter, get by filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Returns T data</returns>
        T Get(Expression<Func<T, bool>> filter);


        /// <summary>
        /// Get list of datas. If there is filter, get by filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Returns list of T data</returns>
        List<T> GetList(Expression<Func<T, bool>> filter = null);


        /// <summary>
        /// Add new T data
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);


        /// <summary>
        /// Delete T data
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);


        /// <summary>
        /// Update T data
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
    }
}
