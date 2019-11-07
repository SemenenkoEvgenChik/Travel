using TravelAgency.DAL.EF;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositoies.Interfaces;

namespace TravelAgency.DAL.Repositoies
{
    public class StatusClientRepository : BaseRepository<StatusClient>, IStatusClientRepository
    {
        public StatusClientRepository(TravelAgencyContext context) : base(context)
        {
        }
    }
}
