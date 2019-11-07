using System.Collections.Generic;

namespace TravelAgency.BLL.BusinessModels.ResponseModel
{
    public class ListTourOpionsModel
    {
        public List<FoodBLM> Food { get; set; }
        public List<FlightBLM> Flight { get; set; }
        public List<TypeOfRestBLM> TypeOfRest { get; set; }
        public List<TypeOfTourBLM> TypeOfTour { get; set; }
        public List<CountriesBLM> Countries { get; set; }
        public List<CityBLM> Cities { get; set; }
        public List<HotelBLM> Hotels { get; set; }
        public List<MeansOfTransportBLM> MeansOfTransports { get; set; }

        public ListTourOpionsModel()
        {
        }

        public ListTourOpionsModel(List<FoodBLM> food, List<FlightBLM> flight, List<TypeOfRestBLM> typeOfRest,List<TypeOfTourBLM> typeOfTour,
            List<CountriesBLM> countries, List<CityBLM> cities, List<MeansOfTransportBLM> meansOfTransports, List<HotelBLM> hotels)
        {
            Food = food;
            Flight = flight;
            TypeOfRest = typeOfRest;
            TypeOfTour = typeOfTour;
            Countries = countries;
            Cities = cities;
            MeansOfTransports = meansOfTransports;
            Hotels = hotels;
        }
    }
}
