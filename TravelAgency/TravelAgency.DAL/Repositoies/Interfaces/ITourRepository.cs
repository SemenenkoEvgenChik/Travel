using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Models;

namespace TravelAgency.DAL.Repositoies.Interfaces
{
    public interface ITourRepository : IBaseRepository<Tour>
    {
        Task<DALResponsePaginationTourModel<Tour>> GetAllTours(DALRequestPaginationTourModel model);
    }
}
