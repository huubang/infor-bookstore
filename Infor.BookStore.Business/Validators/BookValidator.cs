using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infor.BookStore.Data.Models;

namespace Infor.BookStore.Business.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.Author).NotEmpty();
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.Isbn).NotEmpty();
        }
    }
}
