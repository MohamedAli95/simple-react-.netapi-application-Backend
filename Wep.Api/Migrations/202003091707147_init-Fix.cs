namespace Wep.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initFix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Country", "CityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Country", "CityId", c => c.Int(nullable: false));
        }
    }
}
