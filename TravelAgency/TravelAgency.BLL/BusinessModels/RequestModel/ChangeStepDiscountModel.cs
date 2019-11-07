using System.ComponentModel.DataAnnotations;

namespace TravelAgency.BLL.BusinessModels.RequestModel
{
    public class ChangeStepDiscountModel
    {
        public int IdCustomer { get; set; }
        [Required(ErrorMessage = "Укажите шаг скидки")]
        [Range(0, 100, ErrorMessage = "Шаг скидки возможен от 0 до 20")]
        public int NewStep { get; set; }
    }
}
