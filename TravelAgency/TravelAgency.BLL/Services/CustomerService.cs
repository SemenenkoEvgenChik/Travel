using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.BLL.BusinessModels.IdentityViewModels;
using TravelAgency.BLL.BusinessModels.Pagination;
using TravelAgency.BLL.BusinessModels.RequestModel;
using TravelAgency.BLL.Configs;
using TravelAgency.BLL.FilterModel;
using TravelAgency.BLL.Helpers;
using TravelAgency.BLL.Mapping;
using TravelAgency.BLL.Services.Interface;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.UnitOfWork.Interface;

namespace TravelAgency.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWorks _db;
        private readonly ApplicationUserManager _userManager;

        private const string messageSubject = "Ваш новый пароль!";
        private const string messageBody = "Вас приветствует фирма TravelAgency. Используйте этот пароль при входе в учетную запись: ";

        public CustomerService(IUnitOfWorks db, ApplicationUserManager userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<CustomerBLM> GetCustomerByIdentityUserId(string userId)
        {
            var customer = await _db.CustomerRepository.GetCustomerByIdentityUserId(userId);
            var response = MapCustomer.ToCustomerBLM(customer);
            return response;
        }
        public async Task<bool> ChangeTripStatus(int IdTourCustomer, int TripStatus)
        {
            bool response = false;
            var tourCustomer = await _db.TourCustomerRepository.GetByIdAsync(IdTourCustomer);
            tourCustomer.TripStatusId = TripStatus;
            response = await _db.TourCustomerRepository.UpdateAsync(tourCustomer);

            return response;
        }
        public async Task<List<TripStatusBLM>> GetTripStatus()
        {
            var listTripStatus = await _db.TripStatusRepository.GetTripStatusesAsync();
            var listTripStatusBLM = MapTripStatus.ToListTripStatusBLM(listTripStatus);

            return listTripStatusBLM;
        }
        public async Task AddOrderToBuyer(int idOrder, string userId, int numberPerson, int discount)
        {
            var customer = await _db.CustomerRepository.GetCustomerByIdentityUserId(userId);
            var listCustomerTour = await _db.TourCustomerRepository.CustomerTourByCustomerIdAsync(customer.Id);
            int countOrder = listCustomerTour.Where(s => s.TripStatusId == 1).Count();        //Сколько оплачено TripStatusId == 2 оплачено
            if (countOrder >= 1 && customer.DiscountLimit == 0 && customer.DiscountStep == 0)
            {
                customer.DiscountLimit = 10;
                customer.DiscountStep = 1;
                await _db.CustomerRepository.UpdateAsync(customer);
            }
            var tour = await _db.TourRepository.GetByIdAsync(idOrder);
            TourCustomer customerTours = new TourCustomer() { CustomerId = customer.Id, TourId = tour.Id, TripStatusId = 1, NumberPerson = numberPerson, Discount = discount };
            await _db.TourCustomerRepository.CreateAsync(customerTours);
        }
        public async Task<int> GetDiscountByUserId(string userId)
        {
            int countOrder = 0;
            var customer = await _db.CustomerRepository.GetCustomerByIdentityUserId(userId);
            List<TourCustomer> customerTour = await _db.TourCustomerRepository.CustomerTourByCustomerIdAsync(customer.Id);
            int countRegister = customerTour.Where(s => s.TripStatusId == 1).Count();// count register trip status
            int countPaid = customerTour.Where(s => s.TripStatusId == 2).Count();// count paid status
            int countRegisterAndPaid = countRegister + countPaid;
            int countCanceled = customerTour.Where(s => s.TripStatusId == 3).Count(); //count canceled trip status
            if (countCanceled < countRegisterAndPaid)
            {
                countOrder = countRegisterAndPaid - countCanceled;
            }
            else
            {
                countOrder = 0;
            }
            int discount = CustomerDiscount.DiscountCalculation(customer.DiscountStep, customer.DiscountLimit, countOrder);
            return discount;
        }

        public async Task<ApplicationUser> Register(RegisterViewModel model)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            await _userManager.CreateAsync(user, model.Password);
            Customer customer = MapCustomer.ToCustomer(model, user.Id);
            await _db.CustomerRepository.CreateAsync(customer);

            return user;
        }
        public async Task ExternalRegisterCustomer(string name, string surname, string userId)
        {
            Customer customer = new Customer() { Name = name, Surname = surname, UserId = userId, StatusClientId = 1 };
            await _db.CustomerRepository.CreateAsync(customer);
        }
        public async Task<int> CheckStatusCustomer(string userId)
        {
            int response = await _db.CustomerRepository.GetCustomerStatusByIdentityUserId(userId);
            return response;
        }

        public async Task<bool> ChangePassword(ChangePasswordViewModel model, string userId)
        {
            bool response = false;
            if (model.NewPassword != model.ConfirmPassword)
            {
                throw new AppException("Пароль и подтверждение пароля не совпадают.");
            }

            IdentityResult result = await _userManager.ChangePasswordAsync(userId, model.OldPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                throw new AppException(result.Errors.FirstOrDefault());
            }
            else
            {
                response = true;
            }
            return response;
        }
        public async Task<bool> ChangePersonalInformation(ChangePersonalInformationCustomerModel model)
        {
            bool response = false;
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user != null)
            {
                user.Email = model.Email;
                user.UserName = model.Email;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    response = true;
                }
            }
            var customer = await _db.CustomerRepository.GetCustomerByIdentityUserId(model.UserId);
            customer.Name = model.Name;
            customer.Surname = model.Surname;
            response = await _db.CustomerRepository.UpdateAsync(customer);

            return response;
        }
        public async Task<CustomerBLM> GetCustomerInf(int idCustomer)
        {
            var customer = await _db.CustomerRepository.GetByIdAsync(idCustomer);
            var response = MapCustomer.ToCustomerBLM(customer);

            return response;
        }
        public async Task<bool> ForgotPassword(ForgotViewModel forgotView)
        {
            var response = false;
            var user = await _userManager.FindByEmailAsync(forgotView.Email);
            if (user is null)
            {
                throw new AppException("Извините, такой email не зарегистрирован у нас!");
            }
            var password = GenerationPassword.GeneratePassword();
            user.PasswordHash = new PasswordHasher().HashPassword(password);

            string managerEmail = user.Email.ToString();
            MailMessage message = new MailMessage();
            message.To.Add(managerEmail);
            message.Subject = messageSubject;
            message.Body = messageBody + password;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Send(message);

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                response = true;
            }
            return response;
        }
        public async Task<bool> ChangeStepDiscount(int idCustomer, int newStep)
        {
            bool response = false;
            var customer = await _db.CustomerRepository.GetByIdAsync(idCustomer);
            customer.DiscountStep = newStep;
            response = await _db.CustomerRepository.UpdateAsync(customer);

            return response;
        }

        public async Task<bool> ChangeDiscountLimit(int idCustomer, int newLimit)
        {
            bool response = false;
            var customer = await _db.CustomerRepository.GetByIdAsync(idCustomer);
            customer.DiscountLimit = newLimit;
            response = await _db.CustomerRepository.UpdateAsync(customer);

            return response;
        }

        public async Task<bool> ChangeCustomerEmail(ChangeEmailCustomerModel changeEmail)
        {
            var response = false;
            var customer = await _db.CustomerRepository.GetByIdAsync(changeEmail.Id);
            ApplicationUser applicationUser = await _userManager.FindByIdAsync(customer.UserId);
            applicationUser.Email = changeEmail.Email;
            applicationUser.UserName = changeEmail.Email;
            await _userManager.UpdateAsync(applicationUser);
            response = true;

            return response;
        }
        public async Task<CustomerBLM> SearchCustomerByEmail(string email)
        {
            var customer = new Customer();
            CustomerBLM response = new CustomerBLM();
            ApplicationUser applicationUser = new ApplicationUser();

            if (email is null)
            {
                throw new AppException("Email is required.");
            }
            applicationUser = await _userManager.FindByEmailAsync(email);
            if (applicationUser == null)
            {
                throw new AppException("Такой клиент не зарегистрирован!");
            }

            customer = await _db.CustomerRepository.GetCustomerByIdentityUserId(applicationUser.Id);
            response = MapCustomer.ToCustomerBLM(customer);

            return response;
        }
        public async Task<ResponsePaginationCustomersModel> GetAllCustomers(RequestPaginationCustomersModel request)
        {
            var requestModelDAL = MapPaginationModel.ToDALRequestPaginationCustomersModel(request);
            var customers = await _db.CustomerRepository.GetAllCustomers(requestModelDAL);
            ResponsePaginationCustomersModel response = MapPaginationModel.ToResponsePaginationCustomerModel(customers);

            return response;
        }
        public async Task<List<TourCustomerBLM>> GetCustomersInformation(int idCustomer)
        {
            List<TourCustomer> customerTour = await _db.TourCustomerRepository.CustomerTourByCustomerIdAsync(idCustomer);
            var listTourCustomerBLM = MapTourCustomer.ToListTourCustomerBLM(customerTour);

            return listTourCustomerBLM;
        }
        public async Task<bool> LockCustomer(int id)
        {
            bool response = false;
            var customer = await _db.CustomerRepository.GetByIdAsync(id);
            if (customer is null)
            {
                throw new AppException("Не удалось получить клиента!!!");
            }
            else
            {
                customer.StatusClientId = 2;
                response = await _db.CustomerRepository.UpdateAsync(customer);
                if (!response)
                {
                    throw new AppException("Не удалось изменить статус клиента!!!");
                }
            }
            return response;
        }
        public async Task<bool> UnlockCustomer(int id)
        {
            bool response = false;
            var customer = await _db.CustomerRepository.GetByIdAsync(id);
            if (customer is null)
            {
                throw new AppException("Не удалось получить клиента!!!");
            }
            else
            {
                customer.StatusClientId = 1;
                response = await _db.CustomerRepository.UpdateAsync(customer);
                if (!response)
                {
                    throw new AppException("Не удалось изменить статус клиента!!!");
                }
            }
            return response;
        }
    }
}
