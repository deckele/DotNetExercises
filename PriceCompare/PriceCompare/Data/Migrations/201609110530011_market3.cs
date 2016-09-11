namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class market3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Prices", name: "StoreID", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Prices", name: "ChainID", newName: "StoreID");
            RenameColumn(table: "dbo.Prices", name: "__mig_tmp__0", newName: "ChainID");
            RenameIndex(table: "dbo.Prices", name: "IX_StoreID_ChainID", newName: "IX_ChainID_StoreID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Prices", name: "IX_ChainID_StoreID", newName: "IX_StoreID_ChainID");
            RenameColumn(table: "dbo.Prices", name: "ChainID", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Prices", name: "StoreID", newName: "ChainID");
            RenameColumn(table: "dbo.Prices", name: "__mig_tmp__0", newName: "StoreID");
        }
    }
}
