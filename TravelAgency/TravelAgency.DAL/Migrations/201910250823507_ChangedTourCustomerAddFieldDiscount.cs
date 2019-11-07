namespace TravelAgency.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTourCustomerAddFieldDiscount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TourCustomers", "Discount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TourCustomers", "Discount");
        }
    }
}
