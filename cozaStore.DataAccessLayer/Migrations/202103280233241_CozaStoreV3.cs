namespace cozaStore.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CozaStoreV3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductsDetails",
                c => new
                    {
                        ProductDetailID = c.Int(nullable: false, identity: true),
                        Size = c.String(maxLength: 15),
                        Color = c.String(maxLength: 50),
                        Quantity = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductDetailID)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .Index(t => t.ProductID);
            
            DropColumn("dbo.Product", "Size");
            DropColumn("dbo.Product", "Color");
            DropColumn("dbo.Product", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "Color", c => c.String(maxLength: 50));
            AddColumn("dbo.Product", "Size", c => c.String(maxLength: 15));
            DropForeignKey("dbo.ProductsDetails", "ProductID", "dbo.Product");
            DropIndex("dbo.ProductsDetails", new[] { "ProductID" });
            DropTable("dbo.ProductsDetails");
        }
    }
}
