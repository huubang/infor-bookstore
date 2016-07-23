using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infor.BookStore.Connectors.Format
{
    public class BookFormatFactory
    {        
        public static BookFormat Abraham
        {
            get
            {
                return new BookFormat
                {
                    Name = "A",
                    Fields = new List<BookFormatField>
                    {
                        new BookFormatField("Name", 20),
                        new BookFormatField("Isbn", 21),
                        new BookFormatField("Author", 21)
                    }
                };
            }
        }

        public static BookFormat Barack
        {
            get
            {
                return new BookFormat
                {
                    Name = "B",
                    Fields = new List<BookFormatField>
                    {
                        new BookFormatField("Name", 30),
                        new BookFormatField("Isbn", 21),
                        new BookFormatField("Author", 21)
                    }
                };
            }
        }
    }
}
