using FluentValidation.Attributes;
using MVC_Library_Otomasyon.Validations;
using System.Collections.Generic;

namespace MVC_Library_Otomasyon.Model
{
    [Validator(typeof(RolesValidator))]
    public class Roles
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();
    }
}
