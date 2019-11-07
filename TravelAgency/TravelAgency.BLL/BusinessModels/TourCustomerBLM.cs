using System.Collections.Generic;

namespace TravelAgency.BLL.BusinessModels
{
    public class TourCustomerBLM
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int TourId { get; set; }
        public int TripStatusId { get; set; }
        public int NumberPerson { get; set; }
        public int Discount { get; set; }
        public CustomerBLM CustomerBLM { get; set; }
        public TourBLM TourBLM { get; set; }
        public TripStatusBLM TripStatusBLM { get; set; }

        public TourCustomerBLM()
        {
        }

        public TourCustomerBLM(int id, int customerId, int tourId, int tripStatusId, int numberPerson,
            CustomerBLM customerBLL, TourBLM tourBLL, TripStatusBLM tripStatusBLL, int discount)
        {
            Id = id;
            CustomerId = customerId;
            TourId = tourId;
            TripStatusId = tripStatusId;
            NumberPerson = numberPerson;
            CustomerBLM = customerBLL;
            TourBLM = tourBLL;
            TripStatusBLM = tripStatusBLL;
            Discount = discount;
        }
    }
}
