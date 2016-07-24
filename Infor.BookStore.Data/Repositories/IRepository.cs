using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infor.BookStore.Data.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(object id);
        T GetById(object id);
        void Create(T entity);

        /// <summary>
        /// Does a hard delete of the entity.  Override this if you want to soft delete (using status) instead.
        /// </summary>
        void Delete(T entity);

        IQueryable<T> GetAll();
    }

}
