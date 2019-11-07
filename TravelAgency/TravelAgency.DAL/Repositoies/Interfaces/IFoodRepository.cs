using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.DAL.Entities;

namespace TravelAgency.DAL.Repositoies.Interfaces
{
    public interface IFoodRepository : IBaseRepository<Food>
    {
        Task<List<Food>> GetAllFoods();
    }
}
