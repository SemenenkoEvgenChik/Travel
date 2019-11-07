using TravelAgency.DAL.Enums;

namespace TravelAgency.DAL.Models
{
    public class DALRequestPaginationTourModel
    {
        public int NumberPage { get; set; }
        public int SizePage { get; set; }
        public StatusTour StatusTour { get; set; }
        public SortIndex SortIndex { get; set; }
        public DALSerchToursModel DALSerchToursModel { get; set; }
        public DALRequestPaginationTourModel()
        {
            NumberPage = 1;
            SizePage = 10;
        }

        public DALRequestPaginationTourModel(int numberPage, int sizePage, StatusTour statusTour,SortIndex sortIndex, DALSerchToursModel DALSerchToursModel)
        {
            NumberPage = numberPage;
            SizePage = sizePage;
            StatusTour = statusTour;
            SortIndex = sortIndex;
            this.DALSerchToursModel = DALSerchToursModel;
        }
    }
}
