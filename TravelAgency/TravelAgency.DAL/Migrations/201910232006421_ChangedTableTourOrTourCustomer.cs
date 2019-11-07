namespace TravelAgency.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTableTourOrTourCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TourCustomers", "NumberPerson", c => c.Int(nullable: false));
            AddColumn("dbo.Tours", "MaxNumberOfPersons", c => c.Int(nullable: false));
            DropColumn("dbo.Tours", "NumberOfPersons");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tours", "NumberOfPersons", c => c.Int(nullable: false));
            DropColumn("dbo.Tours", "MaxNumberOfPersons");
            DropColumn("dbo.TourCustomers", "NumberPerson");
        }
    }
}
