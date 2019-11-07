using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.BLL.BusinessModels.RequestModel;
using TravelAgency.BLL.Configs;
using TravelAgency.BLL.FilterModel;
using TravelAgency.BLL.Helpers;
using TravelAgency.BLL.Mapping;
using TravelAgency.BLL.Services.Interface;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Enums;
using TravelAgency.DAL.UnitOfWork.Interface;

namespace TravelAgency.BLL.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IUnitOfWorks _db;
        private readonly ApplicationUserManager _userManager;

        private const string messageSubject = "Your Password";
        private const string messageBody = "Вас приветствует фирма TravelAgency. Используйте этот пароль при входе в учетную запись: ";

        public ManagerService(IUnitOfWorks db, ApplicationUserManager userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<bool> DeleteManager(int id)
        {
            bool response = false;
            var manager = await _db.ManagerRepository.GetByIdAsync(id);
            if (manager is null)
            {
                return response;
            }
            string userId = manager.UserId;
            var identityUser = await _userManager.FindByIdAsync(userId);
            response = await _db.ManagerRepository.DeleteAsync(id);
            await _userManager.DeleteAsync(identityUser);
            if (!response)
            {
                throw new AppException("Не удалось удалить менеджера!");
            }
            return response;
        }

        public async Task<bool> DoesSuchMailExist(string email)
        {
            bool response = false;
            var identityUser = await _userManager.FindByEmailAsync(email);
            response = (identityUser is null) ? response : response = true;
            if (response)
            {
                throw new AppException("Менеджер с таким email зарегистрирован!");
            }
            return response;
        }
        public async Task<bool> CreateManager(CreateNewManagerModel request)
        {
            bool response = false;
            var user = new ApplicationUser() { Email = request.Email, UserName = request.Email };
            var password = GenerationPassword.GeneratePassword();
            var createUser = await _userManager.CreateAsync(user, password);
            if (createUser.Succeeded)
            {
                Manager manager = MapManager.ToManager(request, user.Id);
                var createmanager = await _db.ManagerRepository.CreateAsync(manager);
                if (createmanager != null)
                {
                    string managerRole = Roles.manager.ToString();
                    await _userManager.AddToRoleAsync(user.Id, managerRole);

                    string managerEmail = user.Email.ToString();
                    MailMessage message = new MailMessage();
                    message.To.Add(managerEmail);
                    message.Subject = messageSubject;
                    message.Body = messageBody + password;

                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Send(message);
                    response = true;
                }
                else
                {
                    throw new AppException("Не удалось зарегестрировать менеджера!");
                }

            }
            return response;
        }
        public async Task<List<ManagerBLM>> GetAllManagers()
        {
            var managers = await _db.ManagerRepository.GetAllManagers();
            var response = MapManager.ToListManagerBLM(managers);
            return response;
        }

    }
}
