namespace cozaStore.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CozaStoreV6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetail", "ProductID", "dbo.Product");
            DropIndex("dbo.OrderDetail", new[] { "ProductID" });
            DropPrimaryKey("dbo.OrderDetail");
            CreateTable(
                "dbo.ProductDetail",
                c => new
                    {
                        ProductDetailId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        Image = c.String(nullable: false, maxLength: 100),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Size = c.String(maxLength: 15),
                        Color = c.String(maxLength: 50),
                        Quantity = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductDetailId)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .Index(t => t.ProductID);
            
            AddColumn("dbo.OrderDetail", "ProductDetailId", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "UserId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.OrderDetail", new[] { "ProductDetailId", "OrderID" });
            CreateIndex("dbo.OrderDetail", "ProductDetailId");
            CreateIndex("dbo.Order", "UserId");
            AddForeignKey("dbo.Order", "UserId", "dbo.User", "UserID");
            AddForeignKey("dbo.OrderDetail", "ProductDetailId", "dbo.ProductDetail", "ProductDetailId");
            DropColumn("dbo.Product", "Size");
            DropColumn("dbo.Product", "Color");
            DropColumn("dbo.Product", "Quantity");
            DropColumn("dbo.OrderDetail", "ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetail", "ProductID", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "Color", c => c.String(maxLength: 50));
            AddColumn("dbo.Product", "Size", c => c.String(maxLength: 15));
            DropForeignKey("dbo.ProductDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.OrderDetail", "ProductDetailId", "dbo.ProductDetail");
            DropForeignKey("dbo.Order", "UserId", "dbo.User");
            DropIndex("dbo.Order", new[] { "UserId" });
            DropIndex("dbo.OrderDetail", new[] { "ProductDetailId" });
            DropIndex("dbo.ProductDetail", new[] { "ProductID" });
            DropPrimaryKey("dbo.OrderDetail");
            DropColumn("dbo.Order", "UserId");
            DropColumn("dbo.OrderDetail", "ProductDetailId");
            DropTable("dbo.ProductDetail");
            AddPrimaryKey("dbo.OrderDetail", new[] { "ProductID", "OrderID" });
            CreateIndex("dbo.OrderDetail", "ProductID");
            AddForeignKey("dbo.OrderDetail", "ProductID", "dbo.Product", "ProductID");
        }
    }
}
