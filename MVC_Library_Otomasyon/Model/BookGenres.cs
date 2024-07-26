using FluentValidation.Attributes;
using MVC_Library_Otomasyon.Validations;
using System.Collections.Generic;

namespace MVC_Library_Otomasyon.Model
{
    [Validator(typeof(BookGenresValidator))]
    public class BookGenres
    {
        public int Id { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public int GenreId { get; set; }
        public virtual ICollection<Books> Books { get; set; } = new List<Books>();
    }
}
