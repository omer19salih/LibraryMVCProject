using FluentValidation;
using MVC_Library_Otomasyon.Model;
using System;

namespace MVC_Library_Otomasyon.Validations
{
    public class AnnouncementsValidator : AbstractValidator<Announcements>
    {
        public AnnouncementsValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık alanı boş geçilemez")
                .Length(5, 150).WithMessage("Başlık alanı 5-150 karakter arası olmalıdır.");

            RuleFor(x => x.Announcement)
                .NotEmpty().WithMessage("Duyuru alanı boş geçilemez")
                .Length(10, 500).WithMessage("Duyuru alanı 10-500 karakter arası olmalıdır.");

            RuleFor(x => x.Description)
                .Length(10, 5000).WithMessage("Açıklama alanı 10-5000 karakter arası olmalıdır.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Tarih alanı boş geçilemez")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Tarih gelecekte olamaz.");
        }
    }
}
