using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.DAL.Entities;

namespace TravelAgency.DAL.Repositoies.Interfaces
{
    public interface ICountriesRepository : IBaseRepository<Countries>
    {
        Task<List<Countries>> GetAllCountries();
    }
}
