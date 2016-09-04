namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class market3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Stores", "GeoArea");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stores", "GeoArea", c => c.String());
        }
    }
}
