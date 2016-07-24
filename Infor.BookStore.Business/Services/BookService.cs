using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Threading.Tasks;
using Infor.BookStore.Business.Validators;
using Infor.BookStore.Connectors;
using Infor.BookStore.Connectors.Format;
using Infor.BookStore.Data.Models;
using Infor.BookStore.Data.Repositories;

namespace Infor.BookStore.Business.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public Task<List<Book>> GetAllAsync()
        {
            return bookRepository.GetAll().ToListAsync();
        }

        public Task<Book> GetByIdAsync(int id)
        {
            return bookRepository.GetByIdAsync(id);
        }

        public IList<Book>  Import(Stream importStream, BookFormat format)
        {
            IBookParser parser = new BookFileParser(importStream);

            var books = parser.Parse(format, ParseOptions.SkipUniformLengthCheck | ParseOptions.TrimValue);

            return books;
        }

        public void Create(int userId, Book book)
        {
            book.BookId = 0;

            // Validation
            var validator = new BookValidator();

            var validationResult = validator.Validate(book);

            validationResult.AssertIsValid();

            book.SaveStandardFields(userId);

            bookRepository.Create(book);
        }
    }

    public interface IBookService
    {
        Task<List<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        void Create(int userId, Book book);
        IList<Book> Import(Stream importStream, BookFormat format);
    }
}
