using TravelAgency.BLL.BusinessModels;
using TravelAgency.DAL.Entities;

namespace TravelAgency.BLL.Mapping
{
    public static class MapTypeOfRest
    {
        public static TypeOfRestBLM ToTypeOfRestBLL(TypeOfRest typeOfRest)
        {
            return new TypeOfRestBLM(typeOfRest.Id,typeOfRest.Description);
        }
    }
}
