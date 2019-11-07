using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.DAL.Entities;

namespace TravelAgency.DAL.Repositoies.Interfaces
{
    public interface ITypeOfRestRepository : IBaseRepository<TypeOfRest>
    {
        Task<List<TypeOfRest>> GetAllTypeOfRests();
    }
}
