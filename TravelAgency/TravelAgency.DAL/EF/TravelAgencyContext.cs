using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Helpers;

namespace TravelAgency.DAL.EF
{
    public class TravelAgencyContext : IdentityDbContext<ApplicationUser>
    {
        public TravelAgencyContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new TravelAgencyInitializer());
        }
        public static TravelAgencyContext Create()
        {
            return new TravelAgencyContext();
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<TourCustomer> CustomerTours { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<MeansOfTransport> MeansOfTransports { get; set; }
        public DbSet<StatusClient> StatusClients { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TripStatus> TripStatuses { get; set; }
        public DbSet<TypeOfRest> TypeOfRests { get; set; }
        public DbSet<TypeOfTour> TypeOfTours { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Logger> Loggers { get; set; }
    }
}
