using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Infor.BookStore.Business.Validators
{
    public static class ValidationExtension
    {
        public static void AssertIsValid(this ValidationResult result)
        {
            if (!result.IsValid)
                throw new ValidationException(result.Errors);
        }
    }

}
