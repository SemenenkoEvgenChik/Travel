using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.BLL.BusinessModels.Pagination;
using TravelAgency.BLL.BusinessModels.RequestModel;
using TravelAgency.BLL.Services.Interface;
using TravelAgency.WEB.Controllers;
using TravelAgency.WEB.Models;
using TravelAgency.WEB.Models.ViewModels;

namespace TravelAgency.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AllCustomers(RequestPaginationCustomersModel request)
        {
            var responseModel = await _customerService.GetAllCustomers(request);
            CustomerPaginationViewModel model = new CustomerPaginationViewModel() { ResponsePaginationCustomerModel = responseModel };
            return PartialView("_AllCustomers", model);
        }
        [HttpPost]
        public async Task<ActionResult> SearchCustomerByEmail(SearchCustomerByEmail searchCustomerByEmail)
        {
            CustomerBLM customer = await _customerService.SearchCustomerByEmail(searchCustomerByEmail.Email);

            return PartialView("_SearchCustomerByEmail", customer);
        }
        public async Task<ActionResult> Unlock(int id)
        {
            await _customerService.UnlockCustomer(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> Lock(int id)
        {
            await _customerService.LockCustomer(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> GetCustomerInformation(int idCustomer)
        {
            List<TourCustomerBLM> listTourCustomer = await _customerService.GetCustomersInformation(idCustomer);
            List<TripStatusBLM> listTripStatus = await _customerService.GetTripStatus();
            CustomerBLM customerBLM = await _customerService.GetCustomerInf(idCustomer);
            CustomerPersonalAccountViewModel model = new CustomerPersonalAccountViewModel()
            {
                ListCustomerTourBLM = listTourCustomer,
                ListTripStatus = listTripStatus,
                CustomerBLM = customerBLM
            };
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> ChangeTripStatus(int IdTourCustomer, int TripStatus)
        {
            var response = new ModelStateView();
            response.StateResult = await _customerService.ChangeTripStatus(IdTourCustomer, TripStatus);

            return Json(response);
        }
        [HttpPost]
        public async Task<ActionResult> ChangeStepDiscount(ChangeStepDiscountModel model)
        {
            var response = new ModelStateView();
            response.StateResult = await _customerService.ChangeStepDiscount(model.IdCustomer, model.NewStep);

            return Json(response);
        }

        [HttpPost]
        public async Task<ActionResult> ChangeDiscountLimit(ChangeDiscountLimitModel model)
        {
            var response = new ModelStateView();
            response.StateResult = await _customerService.ChangeDiscountLimit(model.IdCustomer, model.NewLimit);

            return Json(response);
        }
        [HttpPost]
        public async Task<ActionResult> ChangeCustomerEmail(ChangeEmailCustomerModel changeEmail)
        {
            var response = new ModelStateView();
            response.StateResult = await _customerService.ChangeCustomerEmail(changeEmail);

            return Json(response);
        }
    }
}