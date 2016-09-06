namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class market5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "City", c => c.String());
            AddColumn("dbo.Stores", "Address", c => c.String());
            DropColumn("dbo.Stores", "Adress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stores", "Adress", c => c.String());
            DropColumn("dbo.Stores", "Address");
            DropColumn("dbo.Stores", "City");
        }
    }
}
