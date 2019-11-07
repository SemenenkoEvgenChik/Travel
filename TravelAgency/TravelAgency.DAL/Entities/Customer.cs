using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.DAL.Entities
{
    public class Customer : BaseEntity
    {
        public int StatusClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserId { get; set; }
        public int DiscountStep { get; set; }
        public int DiscountLimit { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual StatusClient StatusClient { get; set; }
        public virtual ICollection<TourCustomer> CustomerTours { get; set; }

        public Customer()
        {
        }
        public Customer(ApplicationUser user)
        {
            User = user;
        }
        public Customer(string name, string surname, string userId)
        {
            StatusClientId = 1;
            Name = name;
            Surname = surname;
            UserId = userId;
        }
        public Customer(string name, string surname, string userId, ICollection<TourCustomer> tours, int discountStep, int discountLimit)
        {
            StatusClientId = 1;
            Name = name;
            Surname = surname;
            UserId = userId;
            CustomerTours = tours;
            DiscountStep = discountStep;
            DiscountLimit = discountLimit;
        }
    }
}
