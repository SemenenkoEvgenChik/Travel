using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.DAL.EF;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositoies.Interfaces;

namespace TravelAgency.DAL.Repositoies
{
    public class FlightRepository : BaseRepository<Flight>, IFlightRepository
    {
        public FlightRepository(TravelAgencyContext context) : base(context)
        {
        }

        public async Task<List<Flight>> GetAllFlight()
        {
            var flights = await _context.Flights.ToListAsync();
            return flights;
        }

        public int GetIdFlight(Flight flight)
        {
            var entity =  _context.Flights.Where(f => f.FromWhereId == flight.FromWhereId && f.WhereToId == flight.WhereToId && f.MeansOfTransportId == flight.MeansOfTransportId).FirstOrDefault();
            return  entity.Id;
        }
    }
}
