using FluentValidation.Attributes;
using MVC_Library_Otomasyon.Validations;
using System;

namespace MVC_Library_Otomasyon.Model
{
    [Validator(typeof(UserActionsValidator))]
    public class UserActions
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public virtual Users Users { get; set; }
    }
}
