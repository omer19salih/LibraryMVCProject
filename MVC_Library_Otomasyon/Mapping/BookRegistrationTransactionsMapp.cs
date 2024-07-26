using MVC_Library_Otomasyon.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Library_Otomasyon.Mapping
{
    public class BookRegistrationTransactionsMap : EntityTypeConfiguration<BookRegistrationTransactions>
    {
        public BookRegistrationTransactionsMap()
        {
            this.ToTable("BookRegistrationTransactions");
            this.HasKey(x => x.Id); // Primary key
            this.Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // Otomatik artan sayı

            this.Property(x => x.UserId)
                .IsRequired();

            this.Property(x => x.BookId)
                .IsRequired();

            this.Property(x => x.ActionPerformed)
                .HasColumnType("varchar") // Kolon türü
                .IsRequired()
                .HasMaxLength(100); // Max karakter

            this.Property(x => x.Description)
                .HasColumnType("varchar") // Kolon türü
                .IsRequired()
                .HasMaxLength(1000); // Max karakter

            this.Property(x => x.Date)
                .IsRequired();
        }
    }
}
