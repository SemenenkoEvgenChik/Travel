using System.Collections.Generic;
using System.Linq;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.DAL.Entities;

namespace TravelAgency.BLL.Mapping
{
    public static class MapTripStatus
    {
        public static TripStatusBLM ToMapTripStatusBLM(TripStatus tripStatus)
        {
            return new TripStatusBLM(tripStatus.Id,tripStatus.Status);
        }
        public static List<TripStatusBLM> ToListTripStatusBLM(this List<TripStatus> model)
        {
            var response = model.Select(m => MapTripStatus.ToMapTripStatusBLM(m)).ToList();

            return response;
        }
    }
}
