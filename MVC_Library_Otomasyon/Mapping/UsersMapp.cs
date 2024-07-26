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

    public class UsersMap : EntityTypeConfiguration<Users>
    {
        public UsersMap()
        {
            this.ToTable("Users");
            this.HasKey(x => x.Id); // Primary key
            this.Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // Otomatik artan sayı

            this.Property(x => x.Username)
                .HasColumnType("varchar") // Kolon türü
                .IsRequired()
                .HasMaxLength(50); // Max karakter

            this.Property(x => x.Password)
                .HasColumnType("varchar") // Kolon türü
                .IsRequired()
                .HasMaxLength(100); // Max karakter

            this.Property(x => x.FullName)
                .HasColumnType("varchar") // Kolon türü
                .IsRequired()
                .HasMaxLength(150); // Max karakter

            this.Property(x => x.Phone)
                .HasColumnType("varchar") // Kolon türü
                .HasMaxLength(20); // Max karakter

            this.Property(x => x.Address)
                .HasColumnType("varchar") // Kolon türü
                .HasMaxLength(500); // Max karakter

            this.Property(x => x.Email)
                .HasColumnType("varchar") // Kolon türü
                .HasMaxLength(100); // Max karakter

            this.Property(x => x.RegistrationDate)
                .IsRequired();


          
        }
    }
}