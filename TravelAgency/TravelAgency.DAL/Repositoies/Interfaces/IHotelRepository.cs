using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DAL.Entities;

namespace TravelAgency.DAL.Repositoies.Interfaces
{
    public interface IHotelRepository:IBaseRepository<Hotel>
    {
        Task<List<Hotel>> GetAllHotelsAsync();
    }
}
