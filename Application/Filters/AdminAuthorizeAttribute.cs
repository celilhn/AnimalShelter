using Microsoft.AspNetCore.Mvc;
using static Domain.Constants.Constants;

namespace Application.Filters
{
    public class AdminAuthorizeAttribute : TypeFilterAttribute
    {
        public AdminAuthorizeAttribute() : base(typeof(AdminAuthorizeFilterAttribute))
        {
        }
    }
}
