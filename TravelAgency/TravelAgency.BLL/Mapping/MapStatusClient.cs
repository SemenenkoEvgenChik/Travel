using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.DAL.Entities;

namespace TravelAgency.BLL.Mapping
{
    public static class MapStatusClient
    {
        public static StatusClientBLM ToStatusClientBLL(StatusClient client)
        {
            return new StatusClientBLM(client.Id,client.Status);
        }
    }
}
