using TravelAgency.BLL.BusinessModels.RequestModel;
using TravelAgency.BLL.Enums;

namespace TravelAgency.BLL.BusinessModels.Pagination
{
    public class RequestPaginationToursModel
    {
        public int NumberPage { get; set; }
        public int SizePage { get; set; }
        public StatusTourBLL statusTour { get; set; }
        public SortIndexBLL sortIndex { get; set; }
        public SerchToursModel SerchTours { get; set; }
    }
}
