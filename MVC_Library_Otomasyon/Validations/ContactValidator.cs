using FluentValidation;
using MVC_Library_Otomasyon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Library_Otomasyon.Validations
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-mail boş geçilemez");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("E-mail alanı en fazla 100 karakter olabilir");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen bir mail adresi formatı giriniz.");


            RuleFor(x => x.FullName).NotEmpty().WithMessage("Adı Soyadı alanı boş geçilemez");
            RuleFor(x => x.FullName).MaximumLength(150).WithMessage("En fazla 100 karakter olabilir");
            RuleFor(x => x.Title).NotEmpty().WithMessage(" Başlık alanı boş geçilemez");
            RuleFor(x => x.Title).MaximumLength(200).WithMessage("Başlık  alanı en fazla 200 karakter olabilir");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj  alanı boş geçilemez");
            RuleFor(x => x.Message).MaximumLength(500).WithMessage("Mesaj alanı en fazla 500 karakter olabilir");
        }
    }
}
