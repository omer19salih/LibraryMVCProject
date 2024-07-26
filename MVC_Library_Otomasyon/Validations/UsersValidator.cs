using FluentValidation;
using MVC_Library_Otomasyon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Library_Otomasyon.Validations
{
    public class UsersValidator :AbstractValidator <Users>
    {
        public UsersValidator()
        {

            RuleFor(x => x.Email).NotEmpty().WithMessage("E-mail boş geçilemez");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("E-mail alanı en fazla 100 karakter olabilir");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen bir mail adresi formatı giriniz.");


            RuleFor(x => x.FullName).NotEmpty().WithMessage("Adı Soyadı alanı boş geçilemez");
            RuleFor(x => x.FullName).MaximumLength(150).WithMessage("En fazla 150 karakter olabilir");
            RuleFor(x => x.Username).NotEmpty().WithMessage(" Kulanıcı Adı alanı boş geçilemez");
            RuleFor(x => x.Username).MaximumLength(50).WithMessage("Kullanıcı Adı alanı en fazla 200 karakter olabilir");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre  alanı boş geçilemez");
            RuleFor(x => x.Password).MaximumLength(100).WithMessage("Şifre alanı en fazla 100 karakter olabilir");


            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon  alanı boş geçilemez");
            RuleFor(x => x.Phone).MaximumLength(20).WithMessage("Telefon  alanı en fazla 20 karakter olabilir");

            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres  alanı boş geçilemez");
            RuleFor(x => x.Address).MaximumLength(500).WithMessage("Adres  alanı en fazla 500 karakter olabilir");

        }
    }
}
