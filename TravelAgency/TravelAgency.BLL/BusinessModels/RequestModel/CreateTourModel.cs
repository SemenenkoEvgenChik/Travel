using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TravelAgency.BLL.BusinessModels.RequestModel
{
    public class CreateTourModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите дату выезда")]
        public DateTime DepartureDate { get; set; }
        [Required(ErrorMessage = "Укажите дату прибытия")]
        public DateTime ArrivalDate { get; set; }
        [Required(ErrorMessage = "Укажите количество звезд гостиницы")]
        public int HotelId { get; set; }

        [Required(ErrorMessage = "Укажите цену")]
        [Range(0, 100000, ErrorMessage = "Недопустимая цена")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Укажите количество человек")]
        [Range(0, 50, ErrorMessage = "Количество человек от 0 до 50")]
        public int MaxNumberOfPersons { get; set; }
        [Required(ErrorMessage = "Укажите тип питания")]
        public int FoodId { get; set; }
        [Required(ErrorMessage = "Укажите тип отдыха")]
        public int TypeOfRestId { get; set; }
        [Required(ErrorMessage = "Укажите страну")]
        public int CountriesId { get; set; }
        [Required(ErrorMessage = "Укажите статус тура")]
        public int TypeOfTourId { get; set; }
        [Required(ErrorMessage = "Укажите вид транспорта")]
        public int MeansOfTransportId { get; set; }
        [Required(ErrorMessage = "Укажите город")]
        public int? WhereToId { get; set; }
        [Required(ErrorMessage = "Укажите от куда отправлеие")]
        public int? FromWhereId { get; set; }
    }
}
