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

    public class RolesMap : EntityTypeConfiguration<Roles>
    {
        public RolesMap()
        {
            this.ToTable("Roles");
            this.HasKey(x => x.Id); // Primary key
            this.Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // Otomatik artan sayı

            this.Property(x => x.RoleName)
                .HasColumnType("varchar") // Kolon türü
                .IsRequired()
                .HasMaxLength(50); // Max karakter
            
        }
    }
}
