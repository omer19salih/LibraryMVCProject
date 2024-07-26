using FluentValidation;
using MVC_Library_Otomasyon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Library_Otomasyon.Validations
{
    public class BookGenresValidator : AbstractValidator < BookGenres>
    {
        public BookGenresValidator()
        {
            RuleFor(x => x.Genre).NotEmpty().WithMessage(" Kitap Türü alanı boş geçilemez .");
            RuleFor(x => x.Genre).MaximumLength(100).WithMessage(" Kitap  Türü  alanı en fazla 150 karakter olabilir .");
        }
    }
}
