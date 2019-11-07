namespace TravelAgency.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEntityForLogger : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Loggers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        MessageTemplate = c.String(),
                        Level = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                        Exception = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Loggers");
        }
    }
}
