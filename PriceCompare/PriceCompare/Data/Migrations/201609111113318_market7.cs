namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class market7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stores", "ChainID", "dbo.Chains");
            DropForeignKey("dbo.Prices", new[] { "ChainID", "StoreID" }, "dbo.Stores");
            DropForeignKey("dbo.Prices", "ItemID", "dbo.Items");
            AddForeignKey("dbo.Stores", "ChainID", "dbo.Chains", "ChainID", cascadeDelete: true);
            AddForeignKey("dbo.Prices", new[] { "ChainID", "StoreID" }, "dbo.Stores", new[] { "ChainID", "StoreID" }, cascadeDelete: true);
            AddForeignKey("dbo.Prices", "ItemID", "dbo.Items", "ItemID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prices", "ItemID", "dbo.Items");
            DropForeignKey("dbo.Prices", new[] { "ChainID", "StoreID" }, "dbo.Stores");
            DropForeignKey("dbo.Stores", "ChainID", "dbo.Chains");
            AddForeignKey("dbo.Prices", "ItemID", "dbo.Items", "ItemID");
            AddForeignKey("dbo.Prices", new[] { "ChainID", "StoreID" }, "dbo.Stores", new[] { "ChainID", "StoreID" });
            AddForeignKey("dbo.Stores", "ChainID", "dbo.Chains", "ChainID");
        }
    }
}
