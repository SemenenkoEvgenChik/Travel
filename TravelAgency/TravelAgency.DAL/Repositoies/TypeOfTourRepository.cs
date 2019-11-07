using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.DAL.EF;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositoies.Interfaces;

namespace TravelAgency.DAL.Repositoies
{
    public class TypeOfTourRepository : BaseRepository<TypeOfTour>, ITypeOfTourRepository
    {
        public TypeOfTourRepository(TravelAgencyContext context) : base(context)
        {
        }
        public async Task<List<TypeOfTour>> GetAllTypeOfTours()
        {
            var typeOfTours = await _context.TypeOfTours.ToListAsync();
            return typeOfTours;
        }
    }
}
