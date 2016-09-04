namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class market2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prices", "Store_StoreID", "dbo.Stores");
            DropIndex("dbo.Prices", new[] { "Store_StoreID" });
            RenameColumn(table: "dbo.Prices", name: "Store_StoreID", newName: "Store_StorePK");
            DropPrimaryKey("dbo.Stores");
            AddColumn("dbo.Stores", "StorePK", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Prices", "Store_StorePK", c => c.Int());
            AddPrimaryKey("dbo.Stores", "StorePK");
            CreateIndex("dbo.Prices", "Store_StorePK");
            AddForeignKey("dbo.Prices", "Store_StorePK", "dbo.Stores", "StorePK");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prices", "Store_StorePK", "dbo.Stores");
            DropIndex("dbo.Prices", new[] { "Store_StorePK" });
            DropPrimaryKey("dbo.Stores");
            AlterColumn("dbo.Prices", "Store_StorePK", c => c.Long());
            DropColumn("dbo.Stores", "StorePK");
            AddPrimaryKey("dbo.Stores", "StoreID");
            RenameColumn(table: "dbo.Prices", name: "Store_StorePK", newName: "Store_StoreID");
            CreateIndex("dbo.Prices", "Store_StoreID");
            AddForeignKey("dbo.Prices", "Store_StoreID", "dbo.Stores", "StoreID");
        }
    }
}
