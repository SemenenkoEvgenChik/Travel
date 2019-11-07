using System.Collections.Generic;
using System.Linq;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.DAL.Entities;

namespace TravelAgency.BLL.Mapping
{
    public static class MapCity
    {
        public static CityBLM ToCityBLL(City city)
        {
            return new CityBLM(city.Id,city.KeyCountry,city.NameOfCity);
        }
        public static List<CityBLM> ToListCityModel(this List<City> cities)
        {
            List<CityBLM> managerB = new List<CityBLM>();
            var response = cities.Select(m => ToCityBLL(m)).ToList();

            return response;
        }
    }
}
