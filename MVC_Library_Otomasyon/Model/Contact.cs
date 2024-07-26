using FluentValidation.Attributes;
using MVC_Library_Otomasyon.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Library_Otomasyon.Model
{
    [Validator(typeof(ContactValidator))]
    public class Contact
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}

