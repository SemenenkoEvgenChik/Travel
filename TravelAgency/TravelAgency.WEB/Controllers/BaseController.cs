using System;
using System.Net;
using System.Web.Mvc;
using TravelAgency.BLL.FilterModel;
using TravelAgency.BLL.LoggerConfig;

namespace TravelAgency.WEB.Controllers
{
    public class BaseController : Controller
    {

        protected override void OnException(ExceptionContext filterContext)
        {

            if (filterContext.HttpContext.Request.IsAjaxRequest() && filterContext.Exception is AppException)
            {
                HelperStoreSqlLog.WriteFatal(filterContext.Exception, filterContext.Exception.Message);
                filterContext.Result = new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        filterContext.Exception.Message,
                    }
                };
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                HelperStoreSqlLog.WriteFatal(filterContext.Exception, filterContext.Exception.Message);

                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                filterContext.Result = new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        Message = "Internal Server Error"
                    }
                };
            }
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
            {
                HelperStoreSqlLog.WriteFatal(filterContext.Exception, filterContext.Exception.Message);

                string controllerName = (string)filterContext.RouteData.Values["controller"];
                string actionName = (string)filterContext.RouteData.Values["action"];
                HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                filterContext.Result = View("Error", model);
            }


            filterContext.ExceptionHandled = true;
            base.OnException(filterContext);
        }

    }
}
