using FluentValidation;
using MVC_Library_Otomasyon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Library_Otomasyon.Validations
{
    public class BookTransactionsValidator : AbstractValidator <BookTransactions>
    {
        public BookTransactionsValidator()
        {
            RuleFor(x => x.ActionPerformed).MaximumLength(100).WithMessage(" Yapılan işlem alanı en fazla 100 karakter olabilir .");
        }
    }
}
