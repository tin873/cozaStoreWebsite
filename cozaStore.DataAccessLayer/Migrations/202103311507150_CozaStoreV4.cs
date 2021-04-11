namespace cozaStore.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CozaStoreV4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "CreateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Order", "ShippedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Order", "EndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Order", "ShippedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Order", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
