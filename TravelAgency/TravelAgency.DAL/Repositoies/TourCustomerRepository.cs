using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.DAL.EF;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositoies.Interfaces;

namespace TravelAgency.DAL.Repositoies
{
    public class TourCustomerRepository : BaseRepository<TourCustomer>, ICustomerTourRepository
    {
        public TourCustomerRepository(TravelAgencyContext context) : base(context)
        {
        }
        public async Task<List<TourCustomer>> CustomerTourByCustomerIdAsync(int customerId)
        {
            var customerTour = await _context.CustomerTours.Where(i => i.CustomerId == customerId).
                OrderBy(x => x.TripStatus.Id)
                .ToListAsync();
            return customerTour;
        }
        public async Task<bool> CheckingAvailabilityTour(int customerId, int tourId)
        {
            bool response = false;
            var list = await CustomerTourByCustomerIdAsync(customerId);
            foreach (var l in list)
            {
                if (l.TourId == tourId)
                {
                    response = true;
                }
            }
            return response;
        }
    }
}
