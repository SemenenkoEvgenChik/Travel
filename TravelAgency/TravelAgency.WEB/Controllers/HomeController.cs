using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.BLL.BusinessModels.IdentityViewModels;
using TravelAgency.BLL.BusinessModels.Pagination;
using TravelAgency.BLL.BusinessModels.RequestModel;
using TravelAgency.BLL.Services.Interface;
using TravelAgency.WEB.Models;
using TravelAgency.WEB.Models.ViewModels;

namespace TravelAgency.WEB.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICustomerService _customerService;
        private readonly ITourService _tourService;

        public HomeController(ICustomerService customerService, ITourService tourService)
        {
            _customerService = customerService;
            _tourService = tourService;
        }

        public ActionResult Index()
        {
            if (Request.IsAuthenticated && User.IsInRole("admin"))
            {
                return RedirectToAction("Index", "Tour", new { area = "Admin" });
            }
            if (Request.IsAuthenticated && User.IsInRole("manager"))
            {
                return RedirectToAction("Index", "Tour", new { area = "Manager" });
            }
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> GetPersonalInformation(int idCustomer)
        {
            var customer = await _customerService.GetCustomerInf(idCustomer);
            ChangePersonalInformationViewModel model = new ChangePersonalInformationViewModel() { CustomerBLM = customer};
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> ChangePersonalInformation(ChangePersonalInformationCustomerModel model)
        {
            var response = new ModelStateView();
            model.UserId = User.Identity.GetUserId();
            response.StateResult = await _customerService.ChangePersonalInformation(model);

            return Json(response);
        }
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ForgotPassword(ForgotViewModel forgotView)
        {
            var response = new ModelStateView();
            response.StateResult = await _customerService.ForgotPassword(forgotView);

            return Json(response);
        }
        [HttpPost]
        public async Task<ActionResult> AllActiveTours(RequestPaginationToursModel model)
        {
            ResponsePaginationTourModel response = await _tourService.GetAllActiveTours(model);

            return PartialView("_PaginationAllTours", response);
        }

        [Authorize]
        public async Task<ActionResult> Order(int id)
        {
            var userId = User.Identity.GetUserId();
            var tour = await _tourService.GiveTourInfoToBuyer(id, userId);
            int discount = await _customerService.GetDiscountByUserId(userId);
            tour.Discount = discount;
            OrderViewModel model = new OrderViewModel() { TourBLM = tour };
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> RegisterOrder(int idTour, int numberPerson, int discount)
        {
            var response = new ModelStateView();
            var userId = User.Identity.GetUserId();
            await _customerService.AddOrderToBuyer(idTour, userId, numberPerson, discount);
            response.StateResult = true;
            return Json(response);
        }
        public async Task<ActionResult> PersonalAccount()
        {
            var userId = User.Identity.GetUserId();
            CustomerBLM customerBLM = await _customerService.GetCustomerByIdentityUserId(userId);
            List<TourCustomerBLM> listTourCustomer = await _customerService.GetCustomersInformation(customerBLM.Id);
            List<TripStatusBLM> listTripStatus = await _customerService.GetTripStatus();
            int discount = await _customerService.GetDiscountByUserId(userId);
            CustomerPersonalAccountViewModel model = new CustomerPersonalAccountViewModel()
            {
                ListCustomerTourBLM = listTourCustomer,
                ListTripStatus = listTripStatus,
                CustomerBLM = customerBLM,
                Discount = discount
            };
            return View(model);
        }
        public ActionResult Blocked()
        {
            return View();
        }
    }
}