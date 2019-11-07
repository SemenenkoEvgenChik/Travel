using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TravelAgency.WEB.Models;

namespace TravelAgency.WEB.Filters
{
    public class ModelStateFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            bool modelIsValid = context.Controller.ViewData.ModelState.IsValid;

            if (context.HttpContext.Request.IsAjaxRequest() && !modelIsValid)
            {
                var result = new JsonResult();

                var errors = new List<Error>();
                foreach (var v in context.Controller.ViewData.ModelState)
                {
                   var error = new Error() {
                        Key = v.Key,
                        Errors=  v.Value.Errors.Select(e => e.ErrorMessage).ToList()
                    };
                    errors.Add(error);
                    
                }

                result.Data = new ModelStateView(false, errors);
                context.Result = result;
                context.HttpContext.Response.StatusCode = 400;
            }
            base.OnActionExecuting(context);
        }
    }
}