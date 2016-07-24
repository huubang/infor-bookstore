using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infor.BookStore.Data
{
    /// <summary>
    /// Encapsulates the DbContext to restrict the user only to commit changes.  
    /// All other data access should be done through Services by calling Repositories
    /// </summary>
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly BSContext db;

        public UnitOfWork(BSContext db)
        {
            this.db = db;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return db.SaveChangesAsync();
        }
    }

}
