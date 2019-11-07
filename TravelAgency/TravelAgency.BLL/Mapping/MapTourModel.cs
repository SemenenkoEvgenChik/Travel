using System.Collections.Generic;
using System.Linq;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.BLL.BusinessModels.RequestModel;
using TravelAgency.BLL.BusinessModels.ResponseModel;
using TravelAgency.DAL.Entities;

namespace TravelAgency.BLL.Mapping
{
    public static class MapTourModel
    {
        public static Tour ToTour(CreateTourModel requesModel, int flightId)
        {
            return new Tour(requesModel.DepartureDate, requesModel.ArrivalDate, requesModel.Price, requesModel.MaxNumberOfPersons,
             requesModel.FoodId, flightId, requesModel.TypeOfRestId, requesModel.CountriesId, requesModel.TypeOfTourId, requesModel.HotelId);
        }
        public static TourBLM ToTourBLM(Tour model)
        {
            var hotelBLL = MapHotel.ToHotelBLL(model.Hotel);
            var foodBLL = MapFood.ToFoodBLL(model.Food);
            var flightBLL = MapFlight.ToFlightBLL(model.Flight);
            var typeOfRestBLL = MapTypeOfRest.ToTypeOfRestBLL(model.TypeOfRest);
            var typeOfTourBLL = MapTypeOfTour.ToTypeOfTourBLL(model.TypeOfTour);
            var countryBLL = MapCountries.ToCountriesBLL(model.Countries);

            var map = new TourBLM(model.Id, model.DepartureDate, model.ArrivalDate, model.Price, model.MaxNumberOfPersons,
             model.FoodId, model.FlightId, model.CountriesId, model.TypeOfRestId, model.TypeOfTourId, model.HotelId, hotelBLL,
             foodBLL, flightBLL, typeOfRestBLL, typeOfTourBLL, countryBLL);

            return map;
        }

        public static ListTourOpionsModel ToListTourOpionsModel(List<Food> Food, List<Flight> Flight, List<TypeOfRest> TypeOfRest,
            List<TypeOfTour> TypeOfTour, List<Countries> Countries, List<City> Cities, List<MeansOfTransport> MeansOfTransports, List<Hotel> Hotels)
        {

            List<FoodBLM> foodBLL = new List<FoodBLM>();
            List<FlightBLM> flightBLL = new List<FlightBLM>();
            List<TypeOfRestBLM> typeOfRestBLL = new List<TypeOfRestBLM>();
            List<TypeOfTourBLM> typeOfTourBLL = new List<TypeOfTourBLM>();
            List<CountriesBLM> countriesBLL = new List<CountriesBLM>();
            List<CityBLM> citiesBLL = new List<CityBLM>();
            List<MeansOfTransportBLM> meansOfTransportBLL = new List<MeansOfTransportBLM>();
            List<HotelBLM> hotelsBLL = new List<HotelBLM>();

            var fo = Food.Select(x => MapFood.ToFoodBLL(x)).ToList();
            var fl = Flight.Select(x => MapFlight.ToFlightBLL(x)).ToList();
            var tr = TypeOfRest.Select(x => MapTypeOfRest.ToTypeOfRestBLL(x)).ToList();
            var tt = TypeOfTour.Select(x => MapTypeOfTour.ToTypeOfTourBLL(x)).ToList();
            var c = Countries.Select(x => MapCountries.ToCountriesBLL(x)).ToList();
            var city = Cities.Select(x => MapCity.ToCityBLL(x)).ToList();
            var m = MeansOfTransports.Select(x => MapMeansOfTransport.ToMapMeansOfTransportBLL(x)).ToList();
            var h = Hotels.Select(x => MapHotel.ToHotelBLL(x)).ToList();
            var response = new ListTourOpionsModel(fo, fl, tr, tt, c, city, m, h);

            return response;
        }
    }
}
