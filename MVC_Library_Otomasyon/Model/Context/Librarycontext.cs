using MVC_Library_Otomasyon.Model;
using System.Data.Entity;

public class Librarycontext : DbContext
{
    public DbSet<Users> Users { get; set; }
    public DbSet<Roles> Roles { get; set; }
    public DbSet<UserRoles> UserRoles { get; set; }
    public DbSet<UserActions> UserActions { get; set; }
    public DbSet<BorrowedBooks> BorrowedBooks { get; set; }
    public DbSet<Members> Members { get; set; }
    public DbSet<Books> Books { get; set; }
    public DbSet<BookGenres> BookGenres { get; set; }
    public DbSet<BookTransactions> BookTransactions { get; set; }
    public DbSet<Announcements> Announcements { get; set; }
    public DbSet<BookRegistrationTransactions> BookRegistrationTransactions { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Users>()
            .HasKey(u => u.Id)
            .HasMany(u => u.UserRoles)
            .WithRequired(ur => ur.User)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<Roles>()
            .HasKey(r => r.Id)
            .HasMany(r => r.UserRoles)
            .WithRequired(ur => ur.Role)
            .HasForeignKey(ur => ur.RoleId);

        modelBuilder.Entity<UserRoles>()
            .HasKey(ur => ur.Id);

        modelBuilder.Entity<UserActions>()
            .HasKey(ua => ua.Id)
            .HasRequired(ua => ua.Users)
            .WithMany(u => u.UserActions)
            .HasForeignKey(ua => ua.UserId);

        modelBuilder.Entity<Books>()
            .HasKey(b => b.Id)
            .HasRequired(b => b.BookGenres)
            .WithMany(bg => bg.Books)
            .HasForeignKey(b => b.GenreId);

        modelBuilder.Entity<BookGenres>()
            .HasKey(bg => bg.Id);

        modelBuilder.Entity<BorrowedBooks>()
            .HasKey(bb => bb.Id);

        modelBuilder.Entity<BookTransactions>()
            .HasKey(bt => bt.Id)
            .HasRequired(bt => bt.Users)
            .WithMany()
            .HasForeignKey(bt => bt.UserId);

        modelBuilder.Entity<BookRegistrationTransactions>()
            .HasKey(brt => brt.Id)
            .HasRequired(brt => brt.Users)
            .WithMany()
            .HasForeignKey(brt => brt.UserId);
   
    
    
    }
}
