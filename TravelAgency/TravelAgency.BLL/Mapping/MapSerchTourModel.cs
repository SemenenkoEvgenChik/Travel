using TravelAgency.BLL.BusinessModels.RequestModel;
using TravelAgency.DAL.Models;

namespace TravelAgency.BLL.Mapping
{
    public static class MapSerchTourModel
    {
        public static DALSerchToursModel ToDALSerchToursModel(SerchToursModel serchTours)
        {
            var response = new DALSerchToursModel(serchTours?.NumberPerson,serchTours?.PriceDown,serchTours?.PriceUp,serchTours?.NumberOfStars,serchTours?.TypeOfRest);
            return response;
        }
        public static SerchToursModel ToSerchToursModel(DALSerchToursModel serchTours)
        {
            var response = new SerchToursModel(serchTours?.NumberPerson, serchTours?.PriceDown, serchTours?.PriceUp, serchTours?.NumberOfStars, serchTours?.TypeOfRest);
            return response;
        }
    }
}
