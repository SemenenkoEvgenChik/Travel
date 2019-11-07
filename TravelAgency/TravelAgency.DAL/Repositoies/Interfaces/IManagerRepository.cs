using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.DAL.Entities;

namespace TravelAgency.DAL.Repositoies.Interfaces
{
    public interface IManagerRepository : IBaseRepository<Manager>
    {
        Task<IEnumerable<Manager>> GetAllManagers();
    }
}
