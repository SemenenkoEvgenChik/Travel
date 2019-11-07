using System;
using System.ComponentModel.DataAnnotations;

namespace TravelAgency.BLL.BusinessModels.RequestModel
{
    public class TourEditWithoutListOptionModel
    {
        public int IdTour { get; set; }
        public int IdFlight { get; set; }
        [Required(ErrorMessage = "Укажите дату выезда")]
        public DateTime DepartureDate { get; set; }
        [Required(ErrorMessage = "Укажите дату прибытия")]
        public DateTime ArrivalDate { get; set; }
        public int HotelId { get; set; }
        [Required(ErrorMessage = "Укажите цену")]
        [Range(0, 100000, ErrorMessage = "Недопустимая цена")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Укажите количество человек")]
        [Range(0, 50, ErrorMessage = "Количество человек от 0 до 50")]
        public int MaxNumberOfPersons { get; set; }
        public int FoodId { get; set; }
        public int CountriesId { get; set; }
        public int TypeOfRestId { get; set; }
        public int TypeOfTourId { get; set; }
        public int MeansOfTransportId { get; set; }
        public int WhereToId { get; set; }
        public int FromWhereId { get; set; }
    }
}
