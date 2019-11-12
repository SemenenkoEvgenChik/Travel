using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.BLL.BusinessModels.Pagination;
using TravelAgency.BLL.BusinessModels.RequestModel;
using TravelAgency.BLL.BusinessModels.ResponseModel;

namespace TravelAgency.BLL.Services.Interface
{
    public interface ITourService
    {
        Task<bool> ChangeTypeOfTour(int IdTour, int TypeOfTour);
        Task<TourBLM> GiveTourInfoToBuyer(int tourId, string userId);
        Task<ResponsePaginationTourModel> GetAllActiveTours(RequestPaginationToursModel model);
        Task<ResponsePaginationTourModel> GetAllTours(RequestPaginationToursModel model);
        Task<List<CityBLM>> GetCitisForCountry(int CountryId);
        Task<ListTourOpionsModel> GetListOptinModel();
        Task AddTourAndFlight(CreateTourModel requesModel);
        Task<TourBLM> GetTourById(int idTour);
        Task<FlightBLM> GetFlightById(int idFlight);
        Task<bool> EditTour(TourEditWithoutListOptionModel requesModel);

    }
}
