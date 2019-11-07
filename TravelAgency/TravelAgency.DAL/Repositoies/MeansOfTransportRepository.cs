using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TravelAgency.DAL.EF;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositoies.Interfaces;

namespace TravelAgency.DAL.Repositoies
{
    public class MeansOfTransportRepository : BaseRepository<MeansOfTransport>, IMeansOfTransportRepository
    {
        public MeansOfTransportRepository(TravelAgencyContext context) : base(context)
        {
        }

        public async Task<List<MeansOfTransport>> GetAllMeansOfTransports()
        {
            var meansOfTransport = await _context.MeansOfTransports.ToListAsync();

            return meansOfTransport;
        }
    }
}
