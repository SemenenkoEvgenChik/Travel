using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.DAL.Entities;

namespace TravelAgency.DAL.Repositoies.Interfaces
{
    public interface IMeansOfTransportRepository : IBaseRepository<MeansOfTransport>
    {
        Task<List<MeansOfTransport>> GetAllMeansOfTransports();
    }
}
