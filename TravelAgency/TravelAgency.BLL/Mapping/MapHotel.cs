using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.DAL.Entities;

namespace TravelAgency.BLL.Mapping
{
    public static class MapHotel
    {
        public static HotelBLM ToHotelBLL(Hotel hotel)
        {
            return new HotelBLM(hotel.Id,hotel.NumberOfStars);
        }
    }
}
