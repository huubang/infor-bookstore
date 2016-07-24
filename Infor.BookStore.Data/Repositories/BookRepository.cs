using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infor.BookStore.Data.Models;

namespace Infor.BookStore.Data.Repositories
{
    public class BookRepository : Repository<Book>
    {
        public BookRepository(BSContext dbContext) : base(dbContext)
        {
        }
    }

    public interface IBookRepository : IRepository<Book>
    {
        
    }
}
