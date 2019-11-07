using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.DAL.Entities;

namespace TravelAgency.BLL.Mapping
{
    public static class MapFlight
    {
        public static FlightBLM ToFlightBLL(Flight flight)
        {
            CityBLM fromWhere = MapCity.ToCityBLL(flight.FromWhere);
            CityBLM whereTo = MapCity.ToCityBLL(flight.WhereTo);
            MeansOfTransportBLM meansOfTransport = MapMeansOfTransport.ToMapMeansOfTransportBLL(flight.MeansOfTransport);

            return new FlightBLM(flight.Id, flight.MeansOfTransportId, flight.WhereToId, flight.FromWhereId,fromWhere,whereTo,meansOfTransport);
        }
    }
}
