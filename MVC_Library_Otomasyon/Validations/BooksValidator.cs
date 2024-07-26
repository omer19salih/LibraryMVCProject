using FluentValidation;
using MVC_Library_Otomasyon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Library_Otomasyon.Validations
{
    public class BooksValidator : AbstractValidator <Books>
    {
        public BooksValidator()
        {
            RuleFor(x => x.BarcodeNumber).NotEmpty().WithMessage(" BarkodNo alanı boş geçilemez .");
            RuleFor(x => x.BarcodeNumber).MaximumLength(100).WithMessage(" BarkodNo alanı en fazla 150 karakter olabilir .");


            RuleFor(x => x.BookName).NotEmpty().WithMessage(" Kitab Adı  alanı boş geçilemez .");
            RuleFor(x => x.BookName).MaximumLength(200).WithMessage("  Kitab alanı en fazla 200 karakter olabilir .");

            RuleFor(x => x.AuthorName).NotEmpty().WithMessage(" Yazar Adı alanı boş geçilemez .");
            RuleFor(x => x.AuthorName).MaximumLength(150).WithMessage("  Yazar Adı  alanı en fazla 150 karakter olabilir .");

            RuleFor(x => x.Publisher).NotEmpty().WithMessage(" Yayınevi alanı boş geçilemez .");
            RuleFor(x => x.Publisher).MaximumLength(100).WithMessage(" Yayınevi alanı en fazla 150 karakter olabilir .");

        }
    }
}
