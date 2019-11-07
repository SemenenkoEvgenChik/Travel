using System.ComponentModel.DataAnnotations;

namespace TravelAgency.BLL.BusinessModels.RequestModel
{ 
    public class SearchCustomerByEmail
    {
        [Required(ErrorMessage = "Укажите почту")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
