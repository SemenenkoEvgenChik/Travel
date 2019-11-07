using System.Collections.Generic;
using System.Linq;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.DAL.Entities;

namespace TravelAgency.BLL.Mapping
{
    public static class MapTourCustomer
    {
        public static TourCustomerBLM ToCustomerTourBLM(TourCustomer customerTour)
        {
            CustomerBLM customerBLL = MapCustomer.ToCustomerBLM(customerTour.Customer);
            TourBLM TourBLL = MapTourModel.ToTourBLM(customerTour.Tour);
            TripStatusBLM tripStatusBLL = MapTripStatus.ToMapTripStatusBLM(customerTour.TripStatus);
            return new TourCustomerBLM(customerTour.Id,customerTour.CustomerId, customerTour.TourId, customerTour.TripStatusId,customerTour.NumberPerson, customerBLL, TourBLL, tripStatusBLL,customerTour.Discount);
        }
        public static List<TourCustomerBLM> ToListTourCustomerBLM(this List<TourCustomer> tourCustomers)
        {
            List<TourCustomerBLM> listCustomerTourBLL = tourCustomers.Select(x => ToCustomerTourBLM(x)).ToList();
            return listCustomerTourBLL;
        }

    }
}
