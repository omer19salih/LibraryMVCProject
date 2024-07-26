using FluentValidation.Attributes;
using MVC_Library_Otomasyon.Validations;
using System;
using System.Collections.Generic;

namespace MVC_Library_Otomasyon.Model
{
    public class Members
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public int BooksReadCount { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<BorrowedBooks> BorrowedBooks { get; set; } = new List<BorrowedBooks>();
        public virtual ICollection<BookTransactions> BookTransactions { get; set; } = new List<BookTransactions>();
    }
}
