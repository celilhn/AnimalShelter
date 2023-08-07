using Microsoft.AspNetCore.Mvc;
using static Domain.Constants.Constants;

namespace Application.Filters
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute() : base(typeof(AuthorizeFilterAttribute))
        {
        }
    }
}
