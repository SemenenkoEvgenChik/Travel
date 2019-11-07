using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.DAL.Entities;

namespace TravelAgency.DAL.Repositoies.Interfaces
{
    public interface ICustomerTourRepository : IBaseRepository<TourCustomer>
    {
        Task<List<TourCustomer>> CustomerTourByCustomerIdAsync(int customerId);
        Task<bool> CheckingAvailabilityTour(int customerId,int tourId);
    }
}
