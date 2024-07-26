using MVC_Library_Otomasyon.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MVC_Library_Otomasyon.Mapping
{
    public class BorrowedBooksMap : EntityTypeConfiguration<BorrowedBooks>
    {
        public BorrowedBooksMap()
        {
            this.ToTable("BorrowedBooks");
            this.HasKey(x => x.Id); // Primary key
            this.Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // Auto-increment

            this.Property(x => x.MemberId)
                .IsRequired();

            this.Property(x => x.BookId)
                .IsRequired();

            this.Property(x => x.BookCount)
                .IsRequired();

            this.Property(x => x.BorrowedDate)
                .IsRequired();

            this.Property(x => x.ReturnDate)
                .IsRequired();

            // Relationship with Books
            this.HasRequired(x => x.Books)
                .WithMany(x => x.BorrowedBooks)
                .HasForeignKey(x => x.BookId);
        }
    }
}
