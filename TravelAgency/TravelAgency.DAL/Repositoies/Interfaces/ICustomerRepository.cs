using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Models;

namespace TravelAgency.DAL.Repositoies.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<int> GetCustomerStatusByIdentityUserId(string userId);
        Task<DALResponsePaginationCustomersModel<Customer>> GetAllCustomers(DALRequestPaginationCustomersModel model);
        Task<Customer> GetCustomerByIdentityUserId(string userId);
    }
}
