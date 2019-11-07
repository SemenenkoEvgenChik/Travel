using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.DAL.EF;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositoies.Interfaces;

namespace TravelAgency.DAL.Repositoies
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(TravelAgencyContext context) : base(context)
        {
        }

        public async Task<List<City>> GetAllCities()
        {
            var cities = await _context.Cities.ToListAsync();
            return cities;
        }
        public async Task<List<City>> GetCitisForCountry(int CountryId)
        {
            var country = await _context.Countries.Where(i => i.Id == CountryId).FirstOrDefaultAsync();
            var cities = await _context.Cities.Where(k=>k.KeyCountry == country.Key).ToListAsync();
            return cities;
        }
        


    }
}
