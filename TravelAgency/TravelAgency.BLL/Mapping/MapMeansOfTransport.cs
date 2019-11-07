using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.DAL.Entities;

namespace TravelAgency.BLL.Mapping
{
    public static class MapMeansOfTransport
    {
        public static MeansOfTransportBLM ToMapMeansOfTransportBLL(MeansOfTransport map)
        {
            return new MeansOfTransportBLM(map.Id,map.TypeOfTransport);
        }
    }
}
