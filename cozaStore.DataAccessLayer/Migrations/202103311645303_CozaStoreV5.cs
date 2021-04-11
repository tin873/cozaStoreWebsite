namespace cozaStore.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CozaStoreV5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "UserID", "dbo.User");
            DropIndex("dbo.Order", new[] { "UserID" });
            DropColumn("dbo.Order", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Order", "UserID");
            AddForeignKey("dbo.Order", "UserID", "dbo.User", "UserID");
        }
    }
}
