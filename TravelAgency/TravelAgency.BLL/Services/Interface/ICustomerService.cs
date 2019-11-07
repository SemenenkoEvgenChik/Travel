using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.BLL.BusinessModels.IdentityViewModels;
using TravelAgency.BLL.BusinessModels.Pagination;
using TravelAgency.BLL.BusinessModels.RequestModel;
using TravelAgency.DAL.Entities;

namespace TravelAgency.BLL.Services.Interface
{
    public interface ICustomerService
    {
        Task<CustomerBLM> GetCustomerByIdentityUserId(string userId);
        Task<bool> ChangeTripStatus(int IdTourCustomer, int TripStatus);
        Task<List<TripStatusBLM>> GetTripStatus();
        Task AddOrderToBuyer(int idOrder, string userId, int numberPerson, int discount);
        Task<int> GetDiscountByUserId(string userId);
        Task<ApplicationUser> Register(RegisterViewModel model);
        Task ExternalRegisterCustomer(string name, string surname, string userId);
        Task<int> CheckStatusCustomer(string userId);
        Task<bool> ChangePassword(ChangePasswordViewModel model, string userId);
        Task<bool> ChangePersonalInformation(ChangePersonalInformationCustomerModel model);
        Task<CustomerBLM> GetCustomerInf(int idCustomer);
        Task<bool> ForgotPassword(ForgotViewModel forgotView);
        Task<bool> ChangeStepDiscount(int idCustomer, int newStep);
        Task<bool> ChangeDiscountLimit(int idCustomer, int newLimit);
        Task<bool> ChangeCustomerEmail(ChangeEmailCustomerModel changeEmail);
        Task<CustomerBLM> SearchCustomerByEmail(string email);
        Task<ResponsePaginationCustomersModel> GetAllCustomers(RequestPaginationCustomersModel request);
        Task<List<TourCustomerBLM>> GetCustomersInformation(int idCustomer);
        Task<bool> LockCustomer(int id);
        Task<bool> UnlockCustomer(int id);

    }
}
