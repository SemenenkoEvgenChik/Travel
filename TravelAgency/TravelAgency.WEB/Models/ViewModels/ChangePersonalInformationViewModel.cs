using TravelAgency.BLL.BusinessModels;

namespace TravelAgency.WEB.Models.ViewModels
{
    public class ChangePersonalInformationViewModel
    {
        public CustomerBLM CustomerBLM { get; set; }
        public ChangePersonalInformationViewModel()
        {
        }
        public ChangePersonalInformationViewModel(CustomerBLM customerBLM)
        {
            this.CustomerBLM = CustomerBLM;
        }
    }
}