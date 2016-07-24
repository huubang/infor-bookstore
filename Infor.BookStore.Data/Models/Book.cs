using System;
using System.ComponentModel.DataAnnotations;

namespace Infor.BookStore.Data.Models
{
    public partial class Book : EntityBase
    {
        public int BookId { get; set; }

        [ImportField("Name")]
        [Required]
        public string Name { get; set; }

        [ImportField("Isbn")]
        [Required]
        public string Isbn { get; set; }

        [ImportField("Author")]
        [Required]
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
