using FluentValidation.Attributes;
using MVC_Library_Otomasyon.Validations;
using System;
using System.Collections.Generic;

namespace MVC_Library_Otomasyon.Model
{
    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<UserActions> UserActions { get; set; } = new List<UserActions>();
        public virtual ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();
        public virtual ICollection<BorrowedBooks> BorrowedBooks { get; set; } = new List<BorrowedBooks>();
    }
}
