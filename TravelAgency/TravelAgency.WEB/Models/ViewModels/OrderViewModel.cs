using TravelAgency.BLL.BusinessModels;

namespace TravelAgency.WEB.Models.ViewModels
{
    public class OrderViewModel
    {
        public TourBLM TourBLM { get; set; }

        public OrderViewModel()
        {
        }
        public OrderViewModel(TourBLM TourBLM)
        {
            this.TourBLM = TourBLM;
        }
    }
}