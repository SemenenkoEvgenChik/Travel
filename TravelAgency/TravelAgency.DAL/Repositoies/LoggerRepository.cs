using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TravelAgency.DAL.EF;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositoies.Interfaces;

namespace TravelAgency.DAL.Repositoies
{
    public class LoggerRepository : BaseRepository<Logger>, ILoggerRepository
    {
        public LoggerRepository(TravelAgencyContext context) : base(context)
        {
        }
        public async Task<List<Logger>> GetLoggers()
        {
            var response = await _context.Loggers.ToListAsync();

            return response;
        }
    }
}
