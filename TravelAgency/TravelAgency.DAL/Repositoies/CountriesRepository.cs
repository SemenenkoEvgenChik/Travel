using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.DAL.EF;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositoies.Interfaces;

namespace TravelAgency.DAL.Repositoies
{
    public class CountriesRepository : BaseRepository<Countries>, ICountriesRepository
    {
        public CountriesRepository(TravelAgencyContext context) : base(context)
        {
        }

        public async Task<List<Countries>> GetAllCountries()
        {
            var countries = await _context.Countries.ToListAsync();
            return countries;
        }
    }
}
