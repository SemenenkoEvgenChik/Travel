using System.Collections.Generic;
using TravelAgency.BLL.BusinessModels.RequestModel;
using TravelAgency.BLL.Enums;

namespace TravelAgency.BLL.BusinessModels.Pagination
{
    public class ResponsePaginationTourModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } 
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public SortIndexBLL SortIndexBLL { get; set; }
        public IEnumerable<TourBLM>  Tours { get; set; }
        public SerchToursModel SerchTours { get; set; }
        public ResponsePaginationTourModel()
        {
        }

        public ResponsePaginationTourModel(int pageNumber, int pageSize, int totalItems, int totalPages, IEnumerable<TourBLM> tours, SortIndexBLL sortIndexBLL, SerchToursModel SerchTours)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItems = totalItems;
            TotalPages = totalPages;
            Tours = tours;
            SortIndexBLL = sortIndexBLL;
            this.SerchTours = SerchTours;
        }
    }
}
