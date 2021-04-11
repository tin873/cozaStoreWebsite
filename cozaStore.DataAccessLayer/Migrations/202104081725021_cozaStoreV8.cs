namespace cozaStore.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cozaStoreV8 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Order", "EndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "EndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
