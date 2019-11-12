using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.BLL.BusinessModels.Pagination;
using TravelAgency.BLL.BusinessModels.RequestModel;
using TravelAgency.BLL.Services.Interface;
using TravelAgency.WEB.Controllers;
using TravelAgency.WEB.Mapping;
using TravelAgency.WEB.Models;
using TravelAgency.WEB.Models.ViewModels;

namespace TravelAgency.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class TourController : BaseController
    {
        private readonly ITourService _tourService;

        public TourController(ITourService tourService)
        {
            _tourService = tourService;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AllTours(RequestPaginationToursModel model)
        {
            ResponsePaginationTourModel response = await _tourService.GetAllTours(model);

            return PartialView("_PaginationAllTours", response);
        }

        [HttpPost]
        public async Task<ActionResult> GetCitisForCountry(int Id)
        {

            List<CityBLM> listCities = await _tourService.GetCitisForCountry(Id);

            return Json(listCities);
        }

        public async Task<ActionResult> CreateNewTour()
        {
            var listOptions = await _tourService.GetListOptinModel();
            CreateNewTourViewModel model = new CreateNewTourViewModel() { ListTourOpions = listOptions };
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> CreatNewTour(CreateTourModel requesModel)
        {
            var response = new ModelStateView();
            await _tourService.AddTourAndFlight(requesModel);
            response.StateResult = true;

            return Json(response);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id, int flightId)
        {
            var listOptions = await _tourService.GetListOptinModel();
            var flight = await _tourService.GetFlightById(flightId);
            var tour = await _tourService.GetTourById(id);
            TourEditViewModel model = MapTour.ToTourEditViewModel(tour,flight,listOptions);

            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(TourEditWithoutListOptionModel requesModel)
        {
            var response = new ModelStateView();
            response.StateResult = await _tourService.EditTour(requesModel);
            
            return Json(response);
        }
    }
}