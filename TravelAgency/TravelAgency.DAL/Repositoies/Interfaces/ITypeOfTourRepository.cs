using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.DAL.Entities;

namespace TravelAgency.DAL.Repositoies.Interfaces
{
    public interface ITypeOfTourRepository: IBaseRepository<TypeOfTour>
    {
        Task<List<TypeOfTour>> GetAllTypeOfTours();
    }
}
