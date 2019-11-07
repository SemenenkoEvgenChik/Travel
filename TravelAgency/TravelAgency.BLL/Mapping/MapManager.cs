using System.Collections.Generic;
using System.Linq;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.BLL.BusinessModels.RequestModel;
using TravelAgency.DAL.Entities;

namespace TravelAgency.BLL.Mapping
{
    public static class MapManager
    {
        public static ManagerBLM ToManagerBLL(Manager manager)
        {
            return new ManagerBLM(manager.Id, manager.Name, manager.Surname, manager.UserId);
        }
        public static List<ManagerBLM> ToListManagerBLM(this IEnumerable<Manager> manager)
        {
            List<ManagerBLM> managerB= new List<ManagerBLM>();
            var response =  manager.Select(m => ToManagerBLL(m)).ToList();

            return response;
        }
        public static Manager ToManager(CreateNewManagerModel viewModel, string UserId)
        {
            return new Manager(viewModel.Name, viewModel.Surname, UserId);
        }
    }
}
