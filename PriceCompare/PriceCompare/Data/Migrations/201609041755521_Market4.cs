namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Market4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stores", "Chain_ChainID", "dbo.Chains");
            DropForeignKey("dbo.Prices", "Store_StorePK", "dbo.Stores");
            DropIndex("dbo.Stores", new[] { "Chain_ChainID" });
            DropIndex("dbo.Prices", new[] { "Store_StorePK" });
            RenameColumn(table: "dbo.Stores", name: "Chain_ChainID", newName: "ChainID");
            RenameColumn(table: "dbo.Prices", name: "Store_StorePK", newName: "Store_ChainID");
            DropPrimaryKey("dbo.Stores");
            AddColumn("dbo.Prices", "Store_StoreID", c => c.Long());
            AlterColumn("dbo.Stores", "ChainID", c => c.Long(nullable: false));
            AlterColumn("dbo.Prices", "Store_ChainID", c => c.Long());
            AddPrimaryKey("dbo.Stores", new[] { "ChainID", "StoreID" });
            CreateIndex("dbo.Stores", "ChainID");
            CreateIndex("dbo.Prices", new[] { "Store_ChainID", "Store_StoreID" });
            AddForeignKey("dbo.Stores", "ChainID", "dbo.Chains", "ChainID", cascadeDelete: true);
            AddForeignKey("dbo.Prices", new[] { "Store_ChainID", "Store_StoreID" }, "dbo.Stores", new[] { "ChainID", "StoreID" });
            DropColumn("dbo.Stores", "StorePK");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stores", "StorePK", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Prices", new[] { "Store_ChainID", "Store_StoreID" }, "dbo.Stores");
            DropForeignKey("dbo.Stores", "ChainID", "dbo.Chains");
            DropIndex("dbo.Prices", new[] { "Store_ChainID", "Store_StoreID" });
            DropIndex("dbo.Stores", new[] { "ChainID" });
            DropPrimaryKey("dbo.Stores");
            AlterColumn("dbo.Prices", "Store_ChainID", c => c.Int());
            AlterColumn("dbo.Stores", "ChainID", c => c.Long());
            DropColumn("dbo.Prices", "Store_StoreID");
            AddPrimaryKey("dbo.Stores", "StorePK");
            RenameColumn(table: "dbo.Prices", name: "Store_ChainID", newName: "Store_StorePK");
            RenameColumn(table: "dbo.Stores", name: "ChainID", newName: "Chain_ChainID");
            CreateIndex("dbo.Prices", "Store_StorePK");
            CreateIndex("dbo.Stores", "Chain_ChainID");
            AddForeignKey("dbo.Prices", "Store_StorePK", "dbo.Stores", "StorePK");
            AddForeignKey("dbo.Stores", "Chain_ChainID", "dbo.Chains", "ChainID");
        }
    }
}
