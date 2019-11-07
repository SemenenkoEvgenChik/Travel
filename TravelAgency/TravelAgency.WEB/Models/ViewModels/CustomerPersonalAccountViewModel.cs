using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.BLL.BusinessModels;

namespace TravelAgency.WEB.Models.ViewModels
{
    public class CustomerPersonalAccountViewModel
    {
        public CustomerBLM CustomerBLM { get; set; }
        public List<TourCustomerBLM> ListCustomerTourBLM { get; set; }
        public List<TripStatusBLM> ListTripStatus { get; set; }
        public int Discount { get; set; }
        public CustomerPersonalAccountViewModel()
        {
        }
        
    }
}