using System;

namespace Infor.BookStore.Data.Models
{
    public partial class Book
    {
        public int BookId { get; set; }
        [ImportField("Name")]
        public string Name { get; set; }

        [ImportField("Isbn")]
        public string Isbn { get; set; }

        [ImportField("Author")]
        public string Author { get; set; }
    }


    [AttributeUsage(AttributeTargets.Property)]
    public class ImportFieldAttribute : Attribute
    {
        public string Name { get; set; }

        public ImportFieldAttribute(string name)
        {
            Name = name;
        }
    }
}
