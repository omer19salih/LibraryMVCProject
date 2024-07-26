using FluentValidation;
using MVC_Library_Otomasyon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Library_Otomasyon.Validations
{
    public class RolesValidator : AbstractValidator <Roles>
    {
        public RolesValidator()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("Roller   alanı boş geçilemez");
            RuleFor(x => x.RoleName).MaximumLength(50).WithMessage("Roller  alanı en fazla 500 karakter olabilir");
        }
    }
}
