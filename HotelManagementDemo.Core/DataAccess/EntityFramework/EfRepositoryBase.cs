using HotelManagementDemo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HotelManagementDemo.Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TContext, TEntity> : IRepositoryBase<TEntity> 
        where TEntity:class,IEntity,new()
        where TContext : DbContext,new()
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).SingleOrDefault();
            }
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
