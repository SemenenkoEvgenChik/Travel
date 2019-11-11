using TravelAgency.BLL.BusinessModels;
using TravelAgency.DAL.Entities;

namespace TravelAgency.TEST.MoqFile
{
    public class ManagerModel
    {
        public static ManagerBLM GetManagerBLL()
        {
            ManagerBLM manager = new ManagerBLM()
            {
                Id = 1,
                Name = "Manager",
                UserId = "userId"
            };

            return manager;
        }
        public static Manager GetManager()
        {
            Manager manager = new Manager()
            {
                Id = 1,
                Name = "Manager",
                UserId = "userId"
            };

            return manager;
        }
    }
}
