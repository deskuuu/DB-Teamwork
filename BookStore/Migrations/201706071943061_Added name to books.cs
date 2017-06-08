namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addednametobooks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Author_Id", "dbo.Authors");
            DropForeignKey("dbo.Books", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "Author_Id" });
            DropIndex("dbo.Books", new[] { "Genre_Id" });
            AddColumn("dbo.Books", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Authors", "FirstName", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Authors", "LastName", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Books", "Author_Id", c => c.Int());
            AlterColumn("dbo.Books", "Genre_Id", c => c.Int());
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 40));
            CreateIndex("dbo.Books", "Author_Id");
            CreateIndex("dbo.Books", "Genre_Id");
            AddForeignKey("dbo.Books", "Author_Id", "dbo.Authors", "Id");
            AddForeignKey("dbo.Books", "Genre_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Books", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "Genre_Id" });
            DropIndex("dbo.Books", new[] { "Author_Id" });
            AlterColumn("dbo.Genres", "Name", c => c.String());
            AlterColumn("dbo.Books", "Genre_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "Author_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Authors", "LastName", c => c.String());
            AlterColumn("dbo.Authors", "FirstName", c => c.String());
            DropColumn("dbo.Books", "Name");
            CreateIndex("dbo.Books", "Genre_Id");
            CreateIndex("dbo.Books", "Author_Id");
            AddForeignKey("dbo.Books", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Books", "Author_Id", "dbo.Authors", "Id", cascadeDelete: true);
        }
    }
}
