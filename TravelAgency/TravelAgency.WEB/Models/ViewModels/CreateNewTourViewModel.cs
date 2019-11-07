using TravelAgency.BLL.BusinessModels.ResponseModel;

namespace TravelAgency.WEB.Models.ViewModels
{
    public class CreateNewTourViewModel
    {
        public ListTourOpionsModel ListTourOpions { get; set; }
        public CreateNewTourViewModel()
        {
        }
        public CreateNewTourViewModel(ListTourOpionsModel ListTourOpions)
        {
            this.ListTourOpions = ListTourOpions;
        }
    }
}