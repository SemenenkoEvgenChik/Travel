using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DAL.EF;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositoies.Interfaces;

namespace TravelAgency.DAL.Repositoies
{
    public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(TravelAgencyContext context) : base(context)
        {
        }

        public async Task<List<Hotel>> GetAllHotelsAsync()
        {
            var response = await _context.Hotels.ToListAsync();
            return response;
        }
    }
}
