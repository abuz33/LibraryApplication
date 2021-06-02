namespace LibraryApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookName = c.String(nullable: false, maxLength: 50, unicode: false),
                        OrderNumber = c.String(nullable: false, maxLength: 20, unicode: false),
                        InStock = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        WriterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Writers", t => t.WriterId, cascadeDelete: true)
                .Index(t => t.WriterId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Writers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WriterName = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BorrowedBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                        BorrowedDate = c.DateTime(nullable: false),
                        BringDate = c.DateTime(nullable: false),
                        BroughtDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberName = c.String(nullable: false, maxLength: 50, unicode: false),
                        MemberLastname = c.String(nullable: false, maxLength: 50, unicode: false),
                        IdentityNumber = c.String(maxLength: 11, fixedLength: true, unicode: false),
                        PhoneNumber = c.String(maxLength: 11, fixedLength: true, unicode: false),
                        RegistirationDate = c.DateTime(nullable: false),
                        Mail = c.String(maxLength: 100, unicode: false),
                        Password = c.String(maxLength: 32, fixedLength: true, unicode: false),
                        Punishment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryBooks",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Book_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Book_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BorrowedBooks", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Books", "WriterId", "dbo.Writers");
            DropForeignKey("dbo.CategoryBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.CategoryBooks", "Category_Id", "dbo.Categories");
            DropIndex("dbo.CategoryBooks", new[] { "Book_Id" });
            DropIndex("dbo.CategoryBooks", new[] { "Category_Id" });
            DropIndex("dbo.BorrowedBooks", new[] { "MemberId" });
            DropIndex("dbo.Books", new[] { "WriterId" });
            DropTable("dbo.CategoryBooks");
            DropTable("dbo.Members");
            DropTable("dbo.BorrowedBooks");
            DropTable("dbo.Writers");
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
        }
    }
}
