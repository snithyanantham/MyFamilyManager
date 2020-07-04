using Microsoft.EntityFrameworkCore;
using MyFamilyManager.API.Core.Interfaces;
using MyFamilyManager.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFamilyManager.API.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DbSet<T> entities;
        protected readonly MyFamilyManagerDbContext dbContext;
        public BaseRepository(MyFamilyManagerDbContext context)
        {
            this.dbContext = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetById(Guid id)
        {
            return entities.SingleOrDefault(s => s.Id == id); ;
        }

        public void Insert(T entity)
        {
            if (entity == null)
            { throw new ArgumentNullException("entity"); }
            entities.Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            { throw new ArgumentNullException("entity"); }
        }

        public void Delete(Guid id)
        {
            if (id == null)
            { throw new ArgumentNullException("entity"); }

            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
        }
    }
}
