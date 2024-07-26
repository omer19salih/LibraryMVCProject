using MVC_Library_Otomasyon.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MVC_Library_Otomasyon.Mapping
{
    public class BookGenresMap : EntityTypeConfiguration<BookGenres>
    {
        public BookGenresMap()
        {
            this.ToTable("BookGenres");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.Genre)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(100);

            this.Property(x => x.Description)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Genre).HasColumnName("Genre");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
            this.HasMany(t => t.Books)
                .WithRequired(t => t.BookGenres)
                .HasForeignKey(t => t.GenreId);
        }
    }
}
