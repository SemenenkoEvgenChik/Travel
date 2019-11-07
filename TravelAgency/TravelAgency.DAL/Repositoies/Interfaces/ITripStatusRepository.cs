using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.DAL.Entities;

namespace TravelAgency.DAL.Repositoies.Interfaces
{
    public interface ITripStatusRepository : IBaseRepository<TripStatus>
    {
        Task<List<TripStatus>> GetTripStatusesAsync();
    }
}
