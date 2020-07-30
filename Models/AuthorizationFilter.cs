using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace tbscore.Models
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        private readonly IConfiguration _config;
        public AuthorizationFilter(IConfiguration configuration)
        {
            _config = configuration;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!CheckAuthorization(context.HttpContext.Request.Headers["Authorization"]))
            {
                context.Result = new UnauthorizedResult();
            }
        }

        private bool CheckAuthorization(string token)
        {
            if (_config["jwt:secret"] == token)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute() : base(typeof(AuthorizationFilter))
        {
            
        }
    }
}