using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.BLL.BusinessModels.RequestModel;
using TravelAgency.BLL.Services.Interface;
using TravelAgency.WEB.Controllers;
using TravelAgency.WEB.Models;
using TravelAgency.WEB.Models.ViewModels;

namespace TravelAgency.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class ManagerController : BaseController
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }
        public async Task<ActionResult> Index()
        {
            List<ManagerBLM> listManager = await _managerService.GetAllManagers();
            ListManagerViewModel model = new ListManagerViewModel() { Managers = listManager};
            return View(model);
        }
        [HttpGet]
        public ActionResult CreateManager()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateManager(CreateNewManagerModel request)
        {
            var response = new ModelStateView();
            var doesSuchMailExist = await _managerService.DoesSuchMailExist(request.Email);
            if (!doesSuchMailExist)
            {
              response.StateResult =  await _managerService.CreateManager(request);
            }
            
            return Json(response);
        }
        public async Task<ActionResult> DeleteManager(int id)
        {
            await _managerService.DeleteManager(id);

            return RedirectToAction("Index", "Manager");
        }
    }
}