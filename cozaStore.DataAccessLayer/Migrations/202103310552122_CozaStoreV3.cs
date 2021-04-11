namespace cozaStore.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CozaStoreV3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coupon",
                c => new
                    {
                        CouponCode = c.String(nullable: false, maxLength: 20),
                        Discount = c.Int(nullable: false),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.CouponCode);
            
            AddColumn("dbo.Order", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Order", "Description", c => c.String(maxLength: 500));
            AddColumn("dbo.Order", "CouponCode", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Order", "CouponCode");
            AddForeignKey("dbo.Order", "CouponCode", "dbo.Coupon", "CouponCode");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "CouponCode", "dbo.Coupon");
            DropIndex("dbo.Order", new[] { "CouponCode" });
            DropColumn("dbo.Order", "CouponCode");
            DropColumn("dbo.Order", "Description");
            DropColumn("dbo.Order", "EndDate");
            DropTable("dbo.Coupon");
        }
    }
}
