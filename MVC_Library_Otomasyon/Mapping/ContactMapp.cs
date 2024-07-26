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
    public class ContactMap : EntityTypeConfiguration<Contact>
    {
        public ContactMap()
        {
            this.ToTable("Contact");
            this.HasKey(x => x.Id); // Primary key
            this.Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // Otomatik artan sayı

            this.Property(x => x.FullName)
                .HasColumnType("varchar") // Kolon türü
                .IsRequired()
                .HasMaxLength(150); // Max karakter

            this.Property(x => x.Email)
                .HasColumnType("varchar") // Kolon türü
                .IsRequired()
                .HasMaxLength(100); // Max karakter

            this.Property(x => x.Title)
                .HasColumnType("varchar") // Kolon türü
                .IsRequired()
                .HasMaxLength(200); // Max karakter

            this.Property(x => x.Message)
                .HasColumnType("varchar") // Kolon türü
                .IsRequired()
                .HasMaxLength(500); // Max karakter

            this.Property(x => x.Description)
                .HasColumnType("varchar") // Kolon türü
                .IsRequired()
                .HasMaxLength(1000); // Max karakter

            this.Property(x => x.Date)
                .IsRequired();

           
        }
    }
}

