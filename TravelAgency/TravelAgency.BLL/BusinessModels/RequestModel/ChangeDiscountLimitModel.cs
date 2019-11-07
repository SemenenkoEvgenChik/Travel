using System.ComponentModel.DataAnnotations;

namespace TravelAgency.BLL.BusinessModels.RequestModel
{
    public class ChangeDiscountLimitModel
    {
        public int IdCustomer { get; set; }
        [Required(ErrorMessage = "Укажите лимит")]
        [Range(0, 100, ErrorMessage = "Лимит возможен от 0 до 100")]
        public int NewLimit { get; set;  }
    }
}
