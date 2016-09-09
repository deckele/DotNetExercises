namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class market7 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Prices");
            AlterColumn("dbo.Prices", "PriceID", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Prices", "PriceID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Prices");
            AlterColumn("dbo.Prices", "PriceID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Prices", "PriceID");
        }
    }
}
