using MVC_Library_Otomasyon.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MVC_Library_Otomasyon.Mapping
{
    public class BooksMap : EntityTypeConfiguration<Books>
    {
        public BooksMap()
        {
            this.ToTable("Books");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.BarcodeNumber)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(100);

            this.Property(x => x.GenreId)
                .IsRequired();

            this.Property(x => x.BookName)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(200);

            this.Property(x => x.AuthorName)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(150);

            this.Property(x => x.Publisher)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(150);

            this.Property(x => x.StockQuantity)
                .IsRequired();

            this.Property(x => x.PageCount)
                .IsRequired();

            this.Property(x => x.Description)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(1000);

            this.Property(x => x.AddedDate)
                .IsRequired();

            this.Property(x => x.UpdatedDate)
                .IsRequired();

            this.Property(x => x.IsDeleted)
                .IsRequired();

            // Table & Column Mappings
            this.Property(t => t.Id).HasColumnName("Id");

            // Relationships
            this.HasRequired(t => t.BookGenres)
                .WithMany(t => t.Books)
                .HasForeignKey(t => t.GenreId);
        }
    }
}
