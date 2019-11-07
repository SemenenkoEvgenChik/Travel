using System;
using System.Collections.Generic;

namespace TravelAgency.BLL.BusinessModels
{
    public class TourBLM
    {
        public int Id { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int Price { get; set; }
        public int NumberOfPersons { get; set; }
        public int FoodId { get; set; }
        public int FlightId { get; set; }
        public int CountriesId { get; set; }
        public int TypeOfRestId { get; set; }
        public int TypeOfTourId { get; set; }
        public int HotelBLMId { get; set; }
        public int Discount { get; set; }
        public bool AlreadyOrdered { get; set; }
        public HotelBLM HotelBLM { get; set; }
        public FoodBLM FoodBLM { get; set; }
        public FlightBLM FlightBLM { get; set; }
        public TypeOfRestBLM TypeOfRestBLM { get; set; }
        public TypeOfTourBLM TypeOfTourBLM { get; set; }
        public CountriesBLM CountriesBLM { get; set; }

        public TourBLM(int id, DateTime departureDate, DateTime arrivalDate, int price, int numberOfPersons, int foodId, int flightId,
           int countriesId, int typeOfRestId, int typeOfTourId, int hotelBLLId, HotelBLM hotelBLL, FoodBLM food, FlightBLM flight,
           TypeOfRestBLM typeOfRest, TypeOfTourBLM typeOfTour, CountriesBLM countries)
        {
            Id = id;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            Price = price;
            NumberOfPersons = numberOfPersons;
            FoodId = foodId;
            FlightId = flightId;
            CountriesId = countriesId;
            TypeOfRestId = typeOfRestId;
            TypeOfTourId = typeOfTourId;
            HotelBLMId = hotelBLLId;
            HotelBLM = hotelBLL;
            FoodBLM = food;
            FlightBLM = flight;
            TypeOfRestBLM = typeOfRest;
            TypeOfTourBLM = typeOfTour;
            CountriesBLM = countries;
        }
        public TourBLM()
        {
        }

    }
}
