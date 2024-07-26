using FluentValidation.Attributes;
using MVC_Library_Otomasyon.Validations;
using System;
using System.Collections.Generic;

namespace MVC_Library_Otomasyon.Model
{
    public class Books
    {
        public int Id { get; set; }
        public string BarcodeNumber { get; set; }
        public int GenreId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Publisher { get; set; }
        public int StockQuantity { get; set; }
        public int PageCount { get; set; }
        public string Description { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual BookGenres BookGenres { get; set; }
        public virtual ICollection<BorrowedBooks> BorrowedBooks { get; set; } = new List<BorrowedBooks>();
        public virtual ICollection<BookTransactions> BookTransactions { get; set; } = new List<BookTransactions>();
    }
}
