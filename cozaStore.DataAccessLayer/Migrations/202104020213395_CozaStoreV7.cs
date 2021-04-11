namespace cozaStore.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CozaStoreV7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.Comment", "ProductID", "dbo.Product");
            DropForeignKey("dbo.ProductDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "SupplierID", "dbo.Supplier");
            DropForeignKey("dbo.OrderDetail", "ProductDetailId", "dbo.ProductDetail");
            DropForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order");
            DropForeignKey("dbo.Order", "CouponCode", "dbo.Coupon");
            DropForeignKey("dbo.Order", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "RoleID", "dbo.Role");
            DropIndex("dbo.Order", new[] { "StatusId" });
            AddColumn("dbo.Order", "Status", c => c.Int(nullable: false));
            AddForeignKey("dbo.Product", "CategoryID", "dbo.Category", "CategoryID", cascadeDelete: true);
            AddForeignKey("dbo.Comment", "ProductID", "dbo.Product", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.ProductDetail", "ProductID", "dbo.Product", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.Product", "SupplierID", "dbo.Supplier", "SupplierID", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetail", "ProductDetailId", "dbo.ProductDetail", "ProductDetailId", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order", "OrderID", cascadeDelete: true);
            AddForeignKey("dbo.Order", "CouponCode", "dbo.Coupon", "CouponCode", cascadeDelete: true);
            AddForeignKey("dbo.Order", "UserId", "dbo.User", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.User", "RoleID", "dbo.Role", "RoleID", cascadeDelete: true);
            DropColumn("dbo.Order", "StatusId");
            DropTable("dbo.Status");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        StatusName = c.String(nullable: false, maxLength: 30),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.StatusId);
            
            AddColumn("dbo.Order", "StatusId", c => c.Int(nullable: false));
            DropForeignKey("dbo.User", "RoleID", "dbo.Role");
            DropForeignKey("dbo.Order", "UserId", "dbo.User");
            DropForeignKey("dbo.Order", "CouponCode", "dbo.Coupon");
            DropForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order");
            DropForeignKey("dbo.OrderDetail", "ProductDetailId", "dbo.ProductDetail");
            DropForeignKey("dbo.Product", "SupplierID", "dbo.Supplier");
            DropForeignKey("dbo.ProductDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Comment", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropColumn("dbo.Order", "Status");
            CreateIndex("dbo.Order", "StatusId");
            AddForeignKey("dbo.User", "RoleID", "dbo.Role", "RoleID");
            AddForeignKey("dbo.Order", "UserId", "dbo.User", "UserID");
            AddForeignKey("dbo.Order", "CouponCode", "dbo.Coupon", "CouponCode");
            AddForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order", "OrderID");
            AddForeignKey("dbo.OrderDetail", "ProductDetailId", "dbo.ProductDetail", "ProductDetailId");
            AddForeignKey("dbo.Product", "SupplierID", "dbo.Supplier", "SupplierID");
            AddForeignKey("dbo.ProductDetail", "ProductID", "dbo.Product", "ProductID");
            AddForeignKey("dbo.Comment", "ProductID", "dbo.Product", "ProductID");
            AddForeignKey("dbo.Product", "CategoryID", "dbo.Category", "CategoryID");
            AddForeignKey("dbo.Order", "StatusId", "dbo.Status", "StatusId", cascadeDelete: true);
        }
    }
}
