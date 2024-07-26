using System.ComponentModel.DataAnnotations;
using System;
using FluentValidation.Attributes;
using MVC_Library_Otomasyon.Validations;

namespace MVC_Library_Otomasyon.Model
{
    [Validator(typeof(AnnouncementsValidator))]
    public class Announcements
    {
        public int Id { get; set; }


        public string Title { get; set; }

        public string Announcement { get; set; }


        public string Description { get; set; }


        public DateTime Date { get; set; }
    }
}