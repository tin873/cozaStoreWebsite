namespace cozaStore.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CozaStoreV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        Image = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 500),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Size = c.String(maxLength: 15),
                        Color = c.String(maxLength: 50),
                        Quantity = c.Int(nullable: false),
                        SupplierID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Supplier", t => t.SupplierID)
                .ForeignKey("dbo.Category", t => t.CategoryID)
                .Index(t => t.SupplierID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        NameUser = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Content = c.String(nullable: false, maxLength: 500),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        Quantity = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => new { t.ProductID, t.OrderID })
                .ForeignKey("dbo.Order", t => t.OrderID)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .Index(t => t.ProductID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        ShippedDate = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                        FullName = c.String(nullable: false, maxLength: 30),
                        Address = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 20),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        StatusName = c.String(nullable: false, maxLength: 30),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        PassWord = c.String(nullable: false, maxLength: 30, unicode: false),
                        Address = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 20, unicode: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Role", t => t.RoleID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.SupplierID);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ContactID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.Product", "SupplierID", "dbo.Supplier");
            DropForeignKey("dbo.OrderDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.User", "RoleID", "dbo.Role");
            DropForeignKey("dbo.Order", "UserID", "dbo.User");
            DropForeignKey("dbo.Order", "StatusId", "dbo.Status");
            DropForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order");
            DropForeignKey("dbo.Comment", "ProductID", "dbo.Product");
            DropIndex("dbo.User", new[] { "RoleID" });
            DropIndex("dbo.Order", new[] { "StatusId" });
            DropIndex("dbo.Order", new[] { "UserID" });
            DropIndex("dbo.OrderDetail", new[] { "OrderID" });
            DropIndex("dbo.OrderDetail", new[] { "ProductID" });
            DropIndex("dbo.Comment", new[] { "ProductID" });
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropIndex("dbo.Product", new[] { "SupplierID" });
            DropTable("dbo.Contact");
            DropTable("dbo.Supplier");
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.Status");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Comment");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
