namespace MVC_Library_Otomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BorrowedBooks", "BorrowedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BorrowedBooks", "BorrowedDate", c => c.DateTime(nullable: false));
        }
    }
}
