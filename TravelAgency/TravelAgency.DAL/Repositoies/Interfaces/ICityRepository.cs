using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.DAL.Entities;

namespace TravelAgency.DAL.Repositoies.Interfaces
{
    public interface ICityRepository : IBaseRepository<City>
    {
        Task<List<City>> GetAllCities();
        Task<List<City>> GetCitisForCountry(int CountryId);
    }
}
