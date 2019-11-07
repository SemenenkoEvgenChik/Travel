using System.Collections.Generic;

namespace TravelAgency.BLL.BusinessModels
{
    public class CustomerBLM
    {
        public int Id { get; set; }
        public int StatusClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserId { get; set; }
        public int DiscountStep { get; set; }
        public int DiscountLimit { get; set; }
        public ApplicationUserBLM ApplicationUserBLM { get; set; }
        public StatusClientBLM StatusClientBLM { get; set; }
        public ICollection<TourCustomerBLM> CustomerTourBLM { get; set; }

        public CustomerBLM(int id, int statusClientId, string name, string surname, string userId, ApplicationUserBLM applicationUserBLL,
            StatusClientBLM statusClientBLL, int discountStep, int discountLimit, ICollection<TourCustomerBLM> customerTourBLL)
        {
            Id = id;
            StatusClientId = statusClientId;
            Name = name;
            Surname = surname;
            UserId = userId;
            ApplicationUserBLM = applicationUserBLL;
            StatusClientBLM = statusClientBLL;
            DiscountStep = discountStep;
            DiscountLimit = discountLimit;
            CustomerTourBLM = customerTourBLL;
        }
        public CustomerBLM(int id, int statusClientId, string name, string surname, string userId,
            ApplicationUserBLM applicationUserBLL, StatusClientBLM statusClientBLL,int discountStep, int discountLimit)
        {
            Id = id;
            StatusClientId = statusClientId;
            Name = name;
            Surname = surname;
            UserId = userId;
            ApplicationUserBLM = applicationUserBLL;
            StatusClientBLM = statusClientBLL;
            DiscountLimit = discountLimit;
            DiscountStep = discountStep;
        }
        public CustomerBLM()
        {
        }
    }
}
