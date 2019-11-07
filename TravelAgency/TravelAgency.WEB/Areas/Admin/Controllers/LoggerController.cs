using System.Threading.Tasks;
using System.Web.Mvc;
using TravelAgency.BLL.Services.Interface;
using TravelAgency.WEB.Models.ViewModels;

namespace TravelAgency.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class LoggerController : Controller
    {
        private readonly ILoggerService _loggerService;

        public LoggerController(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }
        public async Task<ActionResult> Index()
        {
            var listLoggers = await _loggerService.GetLogger();
            ListLoggersViewModel model = new ListLoggersViewModel() { ListLoggerBLM = listLoggers};
            
            return View(model);
        }
    }
}