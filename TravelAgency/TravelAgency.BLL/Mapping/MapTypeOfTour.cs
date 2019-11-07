using TravelAgency.BLL.BusinessModels;
using TravelAgency.DAL.Entities;

namespace TravelAgency.BLL.Mapping
{
    public static class MapTypeOfTour
    {
        public static TypeOfTourBLM ToTypeOfTourBLL(TypeOfTour typeOfTour)
        {
            return new TypeOfTourBLM(typeOfTour.Id,typeOfTour.Description);
        }
    }
}
