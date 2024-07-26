using MVC_Library_Otomasyon.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

public class AnnouncementsMap : EntityTypeConfiguration<Announcements>
{
    public AnnouncementsMap()
    {
        this.ToTable("Announcements");
        this.HasKey(x => x.Id); // Primary key
        this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // Auto-increment
        this.Property(x => x.Title).IsRequired().HasMaxLength(150).HasColumnType("varchar"); // Column type and length
        this.Property(x => x.Announcement).IsRequired().HasMaxLength(500);
        this.Property(x => x.Description).IsRequired().HasMaxLength(5000);
        this.Property(x => x.Date).IsRequired();

        this.Property(x => x.Id).HasColumnName("id");
        this.Property(x => x.Title).HasColumnName("title");
        this.Property(x => x.Announcement).HasColumnName("Announcement");
        this.Property(x => x.Description).HasColumnName("description");
        this.Property(x => x.Date).HasColumnName("date");
    }
}
