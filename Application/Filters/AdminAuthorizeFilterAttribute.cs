using System.Linq;
using Application.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Application.Filters
{
    public class AdminAuthorizeFilterAttribute : ActionFilterAttribute, IActionFilter
    {
        public AdminAuthorizeFilterAttribute()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int authorizationResult = 0;
            User user = null;
            try
            {
                user = context.HttpContext.Session.GetObjectFromJson<User>("AdminUser");
            }
            catch
            {
                user = null;
            }

            if (user != null && user.ID > 0)
            {
                if (user.Role.Name.Contains("Admin"))
                {
                    authorizationResult = 1;
                }
                else
                {
                    authorizationResult = -1;
                }
            }
            else
            {
                authorizationResult = -1;
            }

            if (authorizationResult == -1)
            {
                context.Result = new RedirectToActionResult("Login", "PanelLogin", null);
            }
            else if (authorizationResult == 0)
            {
                context.Result = new RedirectToActionResult("Error", "Home", null);
            }
            else if (authorizationResult == 1)
            {
                base.OnActionExecuting(context);
            }
        }
    }
}
