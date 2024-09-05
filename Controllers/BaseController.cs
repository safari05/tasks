using Microsoft.AspNetCore.Mvc;

namespace TodoTask.Web.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext filterContext)
        {
            //check Session here

            var sessionUsernameOrEmail = HttpContext.Session.GetInt32("UserId");
            if (sessionUsernameOrEmail == null)
            {
                filterContext.Result =

                RedirectToAction("Login", "Auth");

                return;

            }
            base.OnActionExecuting(filterContext);
        }
    }
}
