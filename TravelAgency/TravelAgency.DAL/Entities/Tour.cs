using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.DAL.Entities
{
    public class Tour : BaseEntity
    {
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int Price { get; set; }
        public int MaxNumberOfPersons { get; set; }
        public int FoodId { get; set; }
        public int FlightId { get; set; }
        public int CountriesId { get; set; }
        public int TypeOfRestId { get; set; }
        public int TypeOfTourId { get; set; }
        public int HotelId { get; set; }
        public virtual Food Food { get; set; }
        public virtual Flight Flight { get; set; }
        public virtual TypeOfRest TypeOfRest { get; set; }
        public virtual TypeOfTour TypeOfTour { get; set; }
        public virtual Hotel Hotel { get; set; }

        public virtual Countries Countries { get; set; }
        public ICollection<TourCustomer> TourCustomers { get; set; }

        public Tour()
        {
            
        }

        public Tour(DateTime departureDate, DateTime arrivalDate, int price, int numberOfPersons, 
            int foodId, int flightId, int typeOfRestId, int countriesId, int typeOfTourId, int hotelId)
        {
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            Price = price;
            MaxNumberOfPersons = numberOfPersons;
            FoodId = foodId;
            FlightId = flightId;
            TypeOfRestId = typeOfRestId;
            CountriesId = countriesId;
            TypeOfTourId = typeOfTourId;
            HotelId = hotelId;
        }

        public Tour(int id, DateTime departureDate, DateTime arrivalDate, int price, int numberOfPersons,
            int foodId, int flightId, int typeOfRestId, int countriesId, int typeOfTourId, int hotelId) :base(id)
        {
            Id = id;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            Price = price;
            MaxNumberOfPersons = numberOfPersons;
            FoodId = foodId;
            FlightId = flightId;
            TypeOfRestId = typeOfRestId;
            CountriesId = countriesId;
            TypeOfTourId = typeOfTourId;
            HotelId = hotelId;
        }
    }
}
