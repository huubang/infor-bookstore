using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infor.BookStore.Data
{
    public class DatabaseInitialiser : CreateDatabaseIfNotExists<BSContext>
    {
        public DatabaseInitialiser()
        {
        }

        protected override void Seed(BSContext context)
        {
            //TODO: Add initialisation for static and test data
            //var staticData = new StaticData(context);
            //staticData.Init();

            //#if DEBUG
            //var testData = new TestData(context);
            //testData.Init();
            //#endif

            //base.Seed(context);
        }
    }

}
