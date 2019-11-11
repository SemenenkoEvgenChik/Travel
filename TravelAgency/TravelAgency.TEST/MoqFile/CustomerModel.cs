using TravelAgency.BLL.BusinessModels;
using TravelAgency.DAL.Entities;

namespace TravelAgency.TEST.MoqFile
{
    public class CustomerModel
    {
        public static Customer GetCustomer()
        {
            Customer customer = new Customer()
            {
                Id = 1,
                Name = "Customer",
                UserId = "userId"
            };

            return customer;
        }
        public static CustomerBLM GetCustomerBLL()
        {
            CustomerBLM customer = new CustomerBLM()
            {
                Id = 1,
                Name = "Customer",
                UserId = "userId"
            };

            return customer;
        }

    }
}
