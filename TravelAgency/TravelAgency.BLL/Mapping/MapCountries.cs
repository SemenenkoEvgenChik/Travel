using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.DAL.Entities;

namespace TravelAgency.BLL.Mapping
{
    public static class MapCountries
    {
        public static CountriesBLM ToCountriesBLL(Countries countries)
        {
            return new CountriesBLM(countries.Id,countries.Key,countries.NameOfCountry);
        }
    }
}
