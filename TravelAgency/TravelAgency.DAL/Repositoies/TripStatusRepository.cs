using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TravelAgency.DAL.EF;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositoies.Interfaces;

namespace TravelAgency.DAL.Repositoies
{
    public class TripStatusRepository : BaseRepository<TripStatus>, ITripStatusRepository
    {
        public TripStatusRepository(TravelAgencyContext context) : base(context)
        {
        }
        public async Task<List<TripStatus>> GetTripStatusesAsync()
        {
            var list = await _context.TripStatuses.ToListAsync();
            return list;
        }
    }
}
