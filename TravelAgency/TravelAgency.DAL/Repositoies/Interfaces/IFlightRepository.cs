using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.DAL.Entities;

namespace TravelAgency.DAL.Repositoies.Interfaces
{
    public interface IFlightRepository : IBaseRepository<Flight>
    {
        Task<List<Flight>> GetAllFlight();
        int GetIdFlight(Flight flight);
    }
}
