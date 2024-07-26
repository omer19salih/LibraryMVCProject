using FluentValidation.Attributes;
using MVC_Library_Otomasyon.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Library_Otomasyon.Model
{
    [Validator(typeof(AboutUsValidator))]
    public class AboutUs
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
    }
}

