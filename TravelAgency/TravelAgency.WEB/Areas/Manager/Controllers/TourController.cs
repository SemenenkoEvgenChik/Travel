using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TravelAgency.BLL.BusinessModels.Pagination;
using TravelAgency.BLL.Services.Interface;
using TravelAgency.WEB.Controllers;
using TravelAgency.WEB.Models;

namespace TravelAgency.WEB.Areas.Manager.Controllers
{
    [Authorize(Roles = "manager")]
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
        public async Task<ActionResult> ChangeTypeOfTour(int IdTour, int TypeOfTour)
        {
            var response = new ModelStateView();
            response.StateResult = await _tourService.ChangeTypeOfTour(IdTour, TypeOfTour);

            return Json(response);
        }
   
    }
}