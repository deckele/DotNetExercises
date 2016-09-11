namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        ChainID = c.Long(nullable: false),
                        StoreID = c.Long(nullable: false),
                        Name = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChainID, t.StoreID })
                .ForeignKey("dbo.Chains", t => t.ChainID, cascadeDelete: true)
                .Index(t => t.ChainID);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        ItemID = c.Long(nullable: false),
                        StoreID = c.Long(nullable: false),
                        ChainID = c.Long(nullable: false),
                        ItemPrice = c.Double(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ItemID, t.StoreID, t.ChainID })
                .ForeignKey("dbo.Items", t => t.ItemID, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => new { t.StoreID, t.ChainID }, cascadeDelete: true)
                .Index(t => t.ItemID)
                .Index(t => new { t.StoreID, t.ChainID });
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Long(nullable: false),
                        Name = c.String(),
                        Units = c.String(),
                        UnitsQuantity = c.String(),
                        QuantityInPackage = c.String(),
                        InnerBarcode = c.Long(),
                    })
                .PrimaryKey(t => t.ItemID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prices", new[] { "StoreID", "ChainID" }, "dbo.Stores");
            DropForeignKey("dbo.Prices", "ItemID", "dbo.Items");
            DropForeignKey("dbo.Stores", "ChainID", "dbo.Chains");
            DropIndex("dbo.Prices", new[] { "StoreID", "ChainID" });
            DropIndex("dbo.Prices", new[] { "ItemID" });
            DropIndex("dbo.Stores", new[] { "ChainID" });
            DropTable("dbo.Items");
            DropTable("dbo.Prices");
            DropTable("dbo.Stores");
            DropTable("dbo.Chains");
        }
    }
}
