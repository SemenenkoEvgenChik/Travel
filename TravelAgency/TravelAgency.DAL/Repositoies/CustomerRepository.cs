using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.DAL.EF;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Models;
using TravelAgency.DAL.Repositoies.Interfaces;

namespace TravelAgency.DAL.Repositoies
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(TravelAgencyContext context) : base(context)
        {
        }
        public async Task<int> GetCustomerStatusByIdentityUserId(string userId)
        {
            var customer = await _context.Customers.Where(u => u.UserId == userId).FirstOrDefaultAsync();
            int response = customer.StatusClientId;
            return response;
        }
        public async Task<DALResponsePaginationCustomersModel<Customer>> GetAllCustomers(DALRequestPaginationCustomersModel model)
        {
            int pageSize = model.SizePage;
            int page = model.NumberPage;
            int totalItems = await _context.Customers.CountAsync();

            IEnumerable<Customer> customers = await _context.Customers.OrderBy(i=>i.Id).Skip((page - 1) * model.SizePage).Take(pageSize).ToListAsync();

            DALResponsePaginationCustomersModel<Customer> response = new DALResponsePaginationCustomersModel<Customer>
            {
                PageNumber = page,
                TotalItems = totalItems,
                PageSize = pageSize,
                Data = customers,
            };
            return response;
        }
        public async Task<Customer> GetCustomerByIdentityUserId(string userId)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(u => u.UserId == userId);
            return customer;
        }
    }
}
