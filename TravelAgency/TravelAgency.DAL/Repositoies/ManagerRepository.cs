using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TravelAgency.DAL.EF;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositoies.Interfaces;

namespace TravelAgency.DAL.Repositoies
{
    public class ManagerRepository : BaseRepository<Manager>, IManagerRepository
    {
        public ManagerRepository(TravelAgencyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Manager>> GetAllManagers()
        {
            var managers = await _context.Managers.ToListAsync();
            return managers;
        }
    }
}
