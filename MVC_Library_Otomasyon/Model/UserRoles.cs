using FluentValidation.Attributes;
using MVC_Library_Otomasyon.Validations;

namespace MVC_Library_Otomasyon.Model
{
    [Validator(typeof(UserRolesValidator))]
    public class UserRoles
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Users User { get; set; }  // Bu isimlendirme daha doğru
        public virtual Roles Role { get; set; }
    }

}
