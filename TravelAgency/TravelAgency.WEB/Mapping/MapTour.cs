using TravelAgency.BLL.BusinessModels;
using TravelAgency.BLL.BusinessModels.ResponseModel;
using TravelAgency.WEB.Models.ViewModels;

namespace TravelAgency.WEB.Mapping
{
    public static class MapTour
    {
        public static TourEditViewModel ToTourEditViewModel(TourBLM tour, FlightBLM flight, ListTourOpionsModel listTourOpions)
        {
            var response = new TourEditViewModel(tour.Id, flight.Id, tour.DepartureDate, tour.ArrivalDate, tour.HotelBLMId, tour.Price, tour.NumberOfPersons, tour.FoodId,
               tour.FoodId, tour.TypeOfRestId, tour.TypeOfTourId, flight.MeansOfTransportId, flight.WhereToId, flight.FromWhereId, tour.HotelBLM, tour.FoodBLM,
               tour.FlightBLM, tour.TypeOfRestBLM, tour.TypeOfTourBLM, tour.CountriesBLM, listTourOpions);

            return response;
        }
    }
}