using TravelAgency.BLL.BusinessModels;
using TravelAgency.DAL.Entities;

namespace TravelAgency.TEST.MoqFile
{
    public class TourModel
    {
        public static TourBLM GetTourBLL()
        {
            TourBLM tour = new TourBLM()
            {
                Id = 1,
                CountriesId = 1,
                Price = 333,
                FlightId = 1
            };
            return tour;
        }
        public static Tour GetTour()
        {
            Tour tour = new Tour()
            {
                Id = 1,
                CountriesId = 1,
                Price = 333,
                FlightId = 1
            };
            return tour;
        }
    }
}
