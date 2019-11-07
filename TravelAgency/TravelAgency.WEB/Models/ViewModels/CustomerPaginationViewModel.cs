using TravelAgency.BLL.BusinessModels.Pagination;

namespace TravelAgency.WEB.Models.ViewModels
{
    public class CustomerPaginationViewModel
    {
        public ResponsePaginationCustomersModel ResponsePaginationCustomerModel { get; set; }

        public CustomerPaginationViewModel()
        {
        }
        public CustomerPaginationViewModel(ResponsePaginationCustomersModel model)
        {
            this.ResponsePaginationCustomerModel = model;
        }
    }
}