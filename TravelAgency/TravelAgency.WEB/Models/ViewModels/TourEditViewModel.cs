using System;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.BLL.BusinessModels.ResponseModel;

namespace TravelAgency.WEB.Models.ViewModels
{
    public class TourEditViewModel
    {
        public int IdTour { get; set; }
        public int IdFlight { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int HotelId { get; set; }
        public int Price { get; set; }
        public int NumberOfPersons { get; set; }
        public int FoodId { get; set; }
        public int CountriesId { get; set; }
        public int TypeOfRestId { get; set; }
        public int TypeOfTourId { get; set; }
        public int MeansOfTransportId { get; set; }
        public int? WhereToId { get; set; }
        public int? FromWhereId { get; set; }
        public HotelBLM HotelBLM { get; set; }
        public FoodBLM FoodBLM { get; set; }
        public FlightBLM FlightBLM { get; set; }
        public TypeOfRestBLM TypeOfRestBLM { get; set; }
        public TypeOfTourBLM TypeOfTourBLM { get; set; }
        public CountriesBLM CountriesBLM { get; set; }
        public ListTourOpionsModel ListTourOpions { get; set; }

        public TourEditViewModel()
        {
        }

        public TourEditViewModel(int idTour, int idFlight, DateTime departureDate, DateTime arrivalDate, int hotelId,
            int price, int numberOfPersons, int foodId, int countriesId, int typeOfRestId, int typeOfTourId, int meansOfTransportId,
            int? whereToId, int? fromWhereId, HotelBLM hotelBLL, FoodBLM food, FlightBLM flight, TypeOfRestBLM typeOfRest,
            TypeOfTourBLM typeOfTour, CountriesBLM countries, ListTourOpionsModel listTourOpions)
        {
            IdTour = idTour;
            IdFlight = idFlight;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            HotelId = hotelId;
            Price = price;
            NumberOfPersons = numberOfPersons;
            FoodId = foodId;
            CountriesId = countriesId;
            TypeOfRestId = typeOfRestId;
            TypeOfTourId = typeOfTourId;
            MeansOfTransportId = meansOfTransportId;
            WhereToId = whereToId;
            FromWhereId = fromWhereId;
            HotelBLM = hotelBLL;
            FoodBLM = food;
            FlightBLM = flight;
            TypeOfRestBLM = typeOfRest;
            TypeOfTourBLM = typeOfTour;
            CountriesBLM = countries;
            ListTourOpions = listTourOpions;
        }
    }
}