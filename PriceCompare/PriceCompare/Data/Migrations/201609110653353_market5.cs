namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class market5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stores", "ChainID", "dbo.Chains");
            DropForeignKey("dbo.Prices", new[] { "ChainID", "StoreID" }, "dbo.Stores");
            DropForeignKey("dbo.Prices", "ItemID", "dbo.Items");
            AddForeignKey("dbo.Stores", "ChainID", "dbo.Chains", "ChainID");
            AddForeignKey("dbo.Prices", new[] { "ChainID", "StoreID" }, "dbo.Stores", new[] { "ChainID", "StoreID" });
            AddForeignKey("dbo.Prices", "ItemID", "dbo.Items", "ItemID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prices", "ItemID", "dbo.Items");
            DropForeignKey("dbo.Prices", new[] { "ChainID", "StoreID" }, "dbo.Stores");
            DropForeignKey("dbo.Stores", "ChainID", "dbo.Chains");
            AddForeignKey("dbo.Prices", "ItemID", "dbo.Items", "ItemID", cascadeDelete: true);
            AddForeignKey("dbo.Prices", new[] { "ChainID", "StoreID" }, "dbo.Stores", new[] { "ChainID", "StoreID" }, cascadeDelete: true);
            AddForeignKey("dbo.Stores", "ChainID", "dbo.Chains", "ChainID", cascadeDelete: true);
        }
    }
}
