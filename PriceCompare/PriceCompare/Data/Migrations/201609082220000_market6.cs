namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class market6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "UnitsQuantity", c => c.String());
            AddColumn("dbo.Items", "InnerBarcode", c => c.Long());
            AlterColumn("dbo.Items", "QuantityInPackage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "QuantityInPackage", c => c.Int(nullable: false));
            DropColumn("dbo.Items", "InnerBarcode");
            DropColumn("dbo.Items", "UnitsQuantity");
        }
    }
}
