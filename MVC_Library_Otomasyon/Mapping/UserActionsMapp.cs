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
    public class UserActionsMap : EntityTypeConfiguration<UserActions>
    {
        public UserActionsMap()
        {
            this.ToTable("UserActions");
            this.HasKey(x => x.Id); // Primary key
            this.Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // Otomatik artan sayı

            this.Property(x => x.UserId)
                .IsRequired();

            this.Property(x => x.Description)
                .HasColumnType("varchar") // Kolon türü
                .IsRequired()
                .HasMaxLength(500); // Max karakter

            this.Property(x => x.Date)
                .IsRequired();

           this.HasRequired(x=>x.Users).WithMany(x=>x.UserActions).HasForeignKey(x=>x.UserId);
        }
    }
}