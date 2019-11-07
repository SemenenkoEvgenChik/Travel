using TravelAgency.BLL.BusinessModels;
using TravelAgency.BLL.BusinessModels.IdentityViewModels;
using TravelAgency.DAL.Entities;

namespace TravelAgency.BLL.Mapping
{
    public static class MapCustomer
    {
        public static Customer ToCustomer(RegisterViewModel model, string userId)
        {
            return new Customer(model.Name, model.Surname, userId);
        }
        public static CustomerBLM ToCustomerBLM(Customer customer)
        {
            ApplicationUserBLM userBLL = MapApplicationUser.ToApplicationUserBLL(customer.User);
            StatusClientBLM statusBLL = MapStatusClient.ToStatusClientBLL(customer.StatusClient);
            int step = customer.DiscountStep;
            int limit = customer.DiscountLimit;
            var response = new CustomerBLM(customer.Id, customer.StatusClientId, customer.Name, customer.Surname,
                 customer.UserId, userBLL, statusBLL, step, limit);
            return response;
        }
    }
}
