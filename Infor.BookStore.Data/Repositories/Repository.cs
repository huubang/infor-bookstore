using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infor.BookStore.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> DbSet;
        protected readonly BSContext DbContext;

        public Repository(BSContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }

        public virtual Task<T> GetByIdAsync(object id)
        {
            return DbSet.FindAsync(id);
        }

        public virtual T GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet.AsQueryable();
        }

        public virtual void Create(T entity)
        {
            DbSet.Add(entity);
        }

        /// <summary>
        /// Does a hard delete of the entity.  Override this if you want to soft delete (using status) instead.
        /// </summary>
        public virtual void Delete(T entity)
        {
            DbSet.Remove(entity);
        }
    }

}
