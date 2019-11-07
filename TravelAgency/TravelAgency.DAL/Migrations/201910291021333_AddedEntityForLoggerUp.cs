namespace TravelAgency.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEntityForLoggerUp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Loggers", "Properties", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Loggers", "Properties");
        }
    }
}
