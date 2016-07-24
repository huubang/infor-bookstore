using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infor.BookStore.Data.Models;

namespace Infor.BookStore.Data
{
    public class BSContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }

        public BSContext()
        {
            #if DEBUG
            Database.Log = s => Debug.WriteLine(s);
            #endif

            // By turning off lazy loading entities must be explicitly loaded by using Include().  This means we don't accidently make
            // calls to the DB that we're not aware of
            Configuration.LazyLoadingEnabled = false;

            // Disable proxy creation so we are dealing with plain POCO
            Configuration.ProxyCreationEnabled = false;
        }
    }
}
