using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.DAL.Entities;

namespace TravelAgency.DAL.Repositoies.Interfaces
{
    public interface ILoggerRepository : IBaseRepository<Logger>
    {
        Task<List<Logger>> GetLoggers();
    }
}
