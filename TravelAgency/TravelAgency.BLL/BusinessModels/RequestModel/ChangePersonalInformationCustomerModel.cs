using System.ComponentModel.DataAnnotations;

namespace TravelAgency.BLL.BusinessModels.RequestModel
{
    public class ChangePersonalInformationCustomerModel
    {
        public string UserId { get; set; }
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(2)]
        public string Surname { get; set; }

    }
}
