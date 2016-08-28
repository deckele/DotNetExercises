namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chains",
                c => new
                    {
                        ChainID = c.Long(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ChainID);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreID = c.Long(nullable: false),
                        Name = c.String(),
                        Adress = c.String(),
                        GeoArea = c.String(),
                        UpdateDate = c.DateTime(),
                        Chain_ChainID = c.Long(),
                    })
                .PrimaryKey(t => t.StoreID)
                .ForeignKey("dbo.Chains", t => t.Chain_ChainID)
                .Index(t => t.Chain_ChainID);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        PriceID = c.Int(nullable: false, identity: true),
                        ItemPrice = c.Double(nullable: false),
                        UpdateDate = c.DateTime(),
                        Item_ItemID = c.Long(),
                        Store_StoreID = c.Long(),
                    })
                .PrimaryKey(t => t.PriceID)
                .ForeignKey("dbo.Items", t => t.Item_ItemID)
                .ForeignKey("dbo.Stores", t => t.Store_StoreID)
                .Index(t => t.Item_ItemID)
                .Index(t => t.Store_StoreID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Long(nullable: false),
                        Name = c.String(),
                        Units = c.String(),
                        QuantityInPackage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prices", "Store_StoreID", "dbo.Stores");
            DropForeignKey("dbo.Prices", "Item_ItemID", "dbo.Items");
            DropForeignKey("dbo.Stores", "Chain_ChainID", "dbo.Chains");
            DropIndex("dbo.Prices", new[] { "Store_StoreID" });
            DropIndex("dbo.Prices", new[] { "Item_ItemID" });
            DropIndex("dbo.Stores", new[] { "Chain_ChainID" });
            DropTable("dbo.Items");
            DropTable("dbo.Prices");
            DropTable("dbo.Stores");
            DropTable("dbo.Chains");
        }
    }
}
