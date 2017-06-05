namespace BookReservationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Books : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookDefinitions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Author = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        NoOfPages = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Identifier = c.String(),
                        ProductionDate = c.DateTime(nullable: false),
                        Definition_Id = c.Guid(),
                        Lender_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookDefinitions", t => t.Definition_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Lender_Id)
                .Index(t => t.Definition_Id)
                .Index(t => t.Lender_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        TimeOfOrder = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderBooks",
                c => new
                    {
                        Order_Id = c.Guid(nullable: false),
                        Book_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Book_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Book_Id);
            
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Surename", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.OrderBooks", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Books", "Lender_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Books", "Definition_Id", "dbo.BookDefinitions");
            DropForeignKey("dbo.BookDefinitions", "CategoryId", "dbo.BookCategories");
            DropIndex("dbo.OrderBooks", new[] { "Book_Id" });
            DropIndex("dbo.OrderBooks", new[] { "Order_Id" });
            DropIndex("dbo.Books", new[] { "Lender_Id" });
            DropIndex("dbo.Books", new[] { "Definition_Id" });
            DropIndex("dbo.BookDefinitions", new[] { "CategoryId" });
            DropColumn("dbo.AspNetUsers", "Surename");
            DropColumn("dbo.AspNetUsers", "Name");
            DropTable("dbo.OrderBooks");
            DropTable("dbo.Orders");
            DropTable("dbo.Books");
            DropTable("dbo.BookDefinitions");
            DropTable("dbo.BookCategories");
        }
    }
}
