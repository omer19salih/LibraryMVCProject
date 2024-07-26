using FluentValidation.Attributes;
using MVC_Library_Otomasyon.Validations;
using System;

namespace MVC_Library_Otomasyon.Model
{
    public class BookTransactions
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public string ActionPerformed { get; set; }
        public DateTime Date { get; set; }

        public virtual Users Users { get; set; }
        public virtual Members Members { get; set; }
        public virtual Books Books { get; set; }
    }
}
