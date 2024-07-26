using FluentValidation;
using MVC_Library_Otomasyon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Library_Otomasyon.Validations
{
    public class AboutUsValidator: AbstractValidator<AboutUs>
    {
        public AboutUsValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik alanı boş geçilemez");
            RuleFor(x => x.Content).MinimumLength(500).WithMessage("İçerik alanı en fazla 500 karakter olabilir");

        }
    }
}
