using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.DAL.EF;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositoies.Interfaces;

namespace TravelAgency.DAL.Repositoies
{
    public class TypeOfRestRepository : BaseRepository<TypeOfRest>, ITypeOfRestRepository
    {
        public TypeOfRestRepository(TravelAgencyContext context) : base(context)
        {
        }

        public async Task<List<TypeOfRest>> GetAllTypeOfRests()
        {
            var typeOfRests = await _context.TypeOfRests.ToListAsync();
            return typeOfRests;
        }
    }
}
