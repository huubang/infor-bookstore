using System.Collections.Generic;

namespace Infor.BookStore.Connectors.Format
{
    public class BookFormat
    {
        public string Name { get; set; }
        public IList<BookFormatField> Fields { get; set; }
    }

    public class BookFormatField
    {
        public string Name { get; set; }
        public int Length { get; set; }

        public BookFormatField(string name, int length)
        {
            this.Name = name;
            this.Length = length;
        }
    }

    
}
