namespace TravelAgency.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KeyCountry = c.String(),
                        NameOfCity = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        NameOfCountry = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusClientId = c.Int(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        UserId = c.String(maxLength: 128),
                        DiscountStep = c.Int(nullable: false),
                        DiscountLimit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StatusClients", t => t.StatusClientId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.StatusClientId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.StatusClients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TourCustomers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        TourId = c.Int(nullable: false),
                        TripStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Tours", t => t.TourId, cascadeDelete: true)
                .ForeignKey("dbo.TripStatus", t => t.TripStatusId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.TourId)
                .Index(t => t.TripStatusId);
            
            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartureDate = c.DateTime(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                        Price = c.Int(nullable: false),
                        NumberOfPersons = c.Int(nullable: false),
                        FoodId = c.Int(nullable: false),
                        FlightId = c.Int(nullable: false),
                        CountriesId = c.Int(nullable: false),
                        TypeOfRestId = c.Int(nullable: false),
                        TypeOfTourId = c.Int(nullable: false),
                        HotelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountriesId, cascadeDelete: true)
                .ForeignKey("dbo.Flights", t => t.FlightId, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: true)
                .ForeignKey("dbo.Hotels", t => t.HotelId, cascadeDelete: true)
                .ForeignKey("dbo.TypeOfRests", t => t.TypeOfRestId, cascadeDelete: true)
                .ForeignKey("dbo.TypeOfTours", t => t.TypeOfTourId, cascadeDelete: true)
                .Index(t => t.FoodId)
                .Index(t => t.FlightId)
                .Index(t => t.CountriesId)
                .Index(t => t.TypeOfRestId)
                .Index(t => t.TypeOfTourId)
                .Index(t => t.HotelId);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeansOfTransportId = c.Int(nullable: false),
                        WhereToId = c.Int(),
                        FromWhereId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.FromWhereId)
                .ForeignKey("dbo.MeansOfTransports", t => t.MeansOfTransportId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.WhereToId)
                .Index(t => t.MeansOfTransportId)
                .Index(t => t.WhereToId)
                .Index(t => t.FromWhereId);
            
            CreateTable(
                "dbo.MeansOfTransports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeOfTransport = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeOfFood = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOfStars = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeOfRests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeOfTours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TripStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Managers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TourCustomers", "TripStatusId", "dbo.TripStatus");
            DropForeignKey("dbo.Tours", "TypeOfTourId", "dbo.TypeOfTours");
            DropForeignKey("dbo.Tours", "TypeOfRestId", "dbo.TypeOfRests");
            DropForeignKey("dbo.Tours", "HotelId", "dbo.Hotels");
            DropForeignKey("dbo.Tours", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.Tours", "FlightId", "dbo.Flights");
            DropForeignKey("dbo.Flights", "WhereToId", "dbo.Cities");
            DropForeignKey("dbo.Flights", "MeansOfTransportId", "dbo.MeansOfTransports");
            DropForeignKey("dbo.Flights", "FromWhereId", "dbo.Cities");
            DropForeignKey("dbo.TourCustomers", "TourId", "dbo.Tours");
            DropForeignKey("dbo.Tours", "CountriesId", "dbo.Countries");
            DropForeignKey("dbo.TourCustomers", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "StatusClientId", "dbo.StatusClients");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Managers", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Flights", new[] { "FromWhereId" });
            DropIndex("dbo.Flights", new[] { "WhereToId" });
            DropIndex("dbo.Flights", new[] { "MeansOfTransportId" });
            DropIndex("dbo.Tours", new[] { "HotelId" });
            DropIndex("dbo.Tours", new[] { "TypeOfTourId" });
            DropIndex("dbo.Tours", new[] { "TypeOfRestId" });
            DropIndex("dbo.Tours", new[] { "CountriesId" });
            DropIndex("dbo.Tours", new[] { "FlightId" });
            DropIndex("dbo.Tours", new[] { "FoodId" });
            DropIndex("dbo.TourCustomers", new[] { "TripStatusId" });
            DropIndex("dbo.TourCustomers", new[] { "TourId" });
            DropIndex("dbo.TourCustomers", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropIndex("dbo.Customers", new[] { "StatusClientId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Managers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TripStatus");
            DropTable("dbo.TypeOfTours");
            DropTable("dbo.TypeOfRests");
            DropTable("dbo.Hotels");
            DropTable("dbo.Foods");
            DropTable("dbo.MeansOfTransports");
            DropTable("dbo.Flights");
            DropTable("dbo.Tours");
            DropTable("dbo.TourCustomers");
            DropTable("dbo.StatusClients");
            DropTable("dbo.Customers");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
        }
    }
}
