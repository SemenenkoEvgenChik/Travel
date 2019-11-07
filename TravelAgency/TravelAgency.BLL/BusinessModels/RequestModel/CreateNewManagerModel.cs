using System.ComponentModel.DataAnnotations;

namespace TravelAgency.BLL.BusinessModels.RequestModel
{
    public class CreateNewManagerModel
    {
        [Required(ErrorMessage = "Укажите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите Фамилию")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Укажите почту")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
