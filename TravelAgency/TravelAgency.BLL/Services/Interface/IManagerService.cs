using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.BLL.BusinessModels.RequestModel;

namespace TravelAgency.BLL.Services.Interface
{
    public interface IManagerService
    {
        Task<bool> DeleteManager(int id);
        Task<bool> DoesSuchMailExist(string email);
        Task<bool> CreateManager(CreateNewManagerModel request);
        Task<List<ManagerBLM>> GetAllManagers();

    }
}
