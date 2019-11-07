using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.DAL.EF;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositoies.Interfaces;

namespace TravelAgency.DAL.Repositoies
{
    public class FoodRepository : BaseRepository<Food>, IFoodRepository
    {
        public FoodRepository(TravelAgencyContext context) : base(context)
        {
        }

        public async Task<List<Food>> GetAllFoods()
        {
            var foods = await _context.Foods.ToListAsync();
            return foods;
        }
    }
}
