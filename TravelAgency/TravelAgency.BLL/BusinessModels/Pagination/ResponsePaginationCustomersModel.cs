using System.Collections.Generic;

namespace TravelAgency.BLL.BusinessModels.Pagination
{
    public class ResponsePaginationCustomersModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<CustomerBLM> CustomerBLM { get; set; }

        public ResponsePaginationCustomersModel(int pageNumber, int pageSize, int totalItems,
        int totalPages, IEnumerable<CustomerBLM> customerBLM)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItems = totalItems;
            TotalPages = totalPages;
            CustomerBLM = customerBLM;
        }
    }
}
