namespace cozaStore.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CozaStoreV2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderDetail", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetail", "Quantity", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
