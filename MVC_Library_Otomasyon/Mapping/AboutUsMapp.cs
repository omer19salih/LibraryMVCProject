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

    public class AboutUsMap : EntityTypeConfiguration<AboutUs>
    {
        public AboutUsMap()
        {
            this.ToTable("AboutUs");
            this.HasKey(x => x.Id); // Primary key
            this.Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // Otomatik artan sayı

            this.Property(x => x.Content)
                .HasColumnType("varchar") // Kolon türü
                .IsRequired()
                .HasMaxLength(500); // Max karakter

            this.Property(x => x.Description)
                .HasColumnType("varchar") // Kolon türü
                .IsRequired()
                .HasMaxLength(5000); // Max karakter

          
        }
    }
}
