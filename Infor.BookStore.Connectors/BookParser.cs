using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Infor.BookStore.Connectors.Format;
using Infor.BookStore.Data.Models;

namespace Infor.BookStore.Connectors
{
    public class BookFileParser : IBookParser
    {
        private string sourceContent = string.Empty;

        public BookFileParser(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                throw new InvalidOperationException(string.Format("File {0} not found.", path));
            }

            sourceContent = System.IO.File.ReadAllText(path);
        }

        public IList<Book> Parse(BookFormat format)
        {
            var books = new List<Book>();

            if (!string.IsNullOrWhiteSpace(sourceContent))
            {
                var lines = sourceContent.Split(new [] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).ToList();

                lines.RemoveAt(0); // Ignore first line

                foreach (var line in lines)
                {
                    //if (line.Length != format.Fields.Sum(f => f.Length))
                    //{
                    //    throw new InvalidOperationException("Lines are not of uniform lengths");                        
                    //}

                    var cursor = 0;
                    var book = new Book();

                    foreach (var field in format.Fields)
                    {
                        var length = Math.Min(field.Length, line.Length - cursor);
                        var fieldValue = line.Substring(cursor, length);

                        cursor += field.Length;

                        book.SetImportFieldValue(field.Name, fieldValue);
                    }

                    books.Add(book);
                }
            }

            return books;
        }
    }

    public interface IBookParser
    {
        IList<Book> Parse(BookFormat format);
    }

    public static class BookExtension
    {
        public static void SetImportFieldValue(this Book book, string importFieldName, object value)
        {
            var property =
                typeof(Book).GetProperties()
                    .FirstOrDefault(
                        p =>
                            p.GetCustomAttributes(typeof(ImportFieldAttribute))
                                .Any(
                                    a =>
                                        (a is ImportFieldAttribute) &&
                                        ((ImportFieldAttribute)a).Name.Equals(importFieldName, StringComparison.CurrentCultureIgnoreCase)));

            if (property != null)
            {
                property.SetValue(book, value);
            }
        }
    }
}
