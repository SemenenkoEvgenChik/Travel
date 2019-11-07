using TravelAgency.BLL.BusinessModels;
using TravelAgency.DAL.Entities;

namespace TravelAgency.BLL.Mapping
{
    public static class MapApplicationUser
    {
        public static ApplicationUserBLM ToApplicationUserBLL(ApplicationUser user)
        {
            return new ApplicationUserBLM(user.Id,user.Email);
        }
    }
}
