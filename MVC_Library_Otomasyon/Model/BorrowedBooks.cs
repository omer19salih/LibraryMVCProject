using FluentValidation.Attributes;
using MVC_Library_Otomasyon.Validations;
using System;

namespace MVC_Library_Otomasyon.Model
{
    public class BorrowedBooks
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public int BookCount { get; set; }
        public DateTime? BorrowedDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public virtual Members Members { get; set; }
        public virtual Books Books { get; set; }
    }
}
