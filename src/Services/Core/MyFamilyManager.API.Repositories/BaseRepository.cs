using Microsoft.EntityFrameworkCore;
using MyFamilyManager.API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.API.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private DbSet<T> localEntity;
        protected MyFamilyManagerContext dbContext;
        public BaseRepository(MyFamilyManagerContext context)
        {
            this.dbContext = context;
            localEntity = context.Set<T>();
        }
        public T Save(T entity)
        {
            localEntity.Add(entity);
            dbContext.SaveChanges();

            return entity;
        }
    }
}
