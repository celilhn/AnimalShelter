using Application.Extensions;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Application.Filters
{
    public class BasicAuthorizeAttribute : ActionFilterAttribute, IActionFilter
    {
        public BasicAuthorizeAttribute()
        {
            
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            User userDto = null;
            try
            {
                userDto = context.HttpContext.Session.GetObjectFromJson<User>("User");
                context.HttpContext.Items.Add("User", userDto);
            }
            catch
            {
                userDto = null;
            }

            if (userDto != null && userDto.ID > 0)
            {
                var controller = context.Controller as Controller;
                controller.ViewBag.name = userDto.Name;
                base.OnActionExecuting(context);
            }
            else
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }
        }
    }
}
