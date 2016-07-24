using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infor.BookStore.Data.Models
{
    public abstract class EntityBase
    {
        public DateTime CreatedTS { get; set; }
        public int CreatedId { get; set; }
        public DateTime? ModifiedTS { get; set; }
        public int? ModifiedId { get; set; }

        protected EntityBase()
        {
            CreatedId = -1;
            CreatedTS = DateTime.UtcNow;
        }

        public void SaveStandardFields(int contactId)
        {
            if (CreatedId == 0 || CreatedId == -1)
            {
                CreatedId = contactId;
                CreatedTS = DateTime.UtcNow;
            }

            ModifiedId = contactId;
            ModifiedTS = DateTime.UtcNow;
        }
    }
}
