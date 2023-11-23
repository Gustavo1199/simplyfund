using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.GeneralConfiguration.Autentication
{
    public class AuthAttribute : TypeFilterAttribute
    {
        public AuthAttribute() : base(typeof(CustomAuthorizeFilter))
        {
        }

        public class CustomAuthorizeFilter : IAuthorizationFilter, IActionFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].ToString();

                if (authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    var token = authorizationHeader.Substring("Bearer ".Length).Trim();
                    ClaimsPrincipal principal;

                    
                    if (TokenService.ValidateToken(token, out principal))
                    {
                        var userIdFromToken = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                        var userIdFromRequest = context.HttpContext.Request.Headers["UserId"].ToString();

                        if (userIdFromToken != userIdFromRequest)
                        {
                            context.Result = new ForbidResult(); 
                            return;
                        }

                        context.HttpContext.Items["UserId"] = userIdFromToken;
               

                        return;
                    }
                }

                context.Result = new UnauthorizedResult();
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                var actionName = context.ActionDescriptor.RouteValues["action"];

                var userId = context.HttpContext.Items["UserId"] as string;
                var userRole = context.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;

                if (!HasPermission(userId, userRole, actionName))
                {
                    context.Result = new ForbidResult(); 
                }
            }

            public void OnActionExecuted(ActionExecutedContext context)
            {

            }

            private bool HasPermission(string userId, string userRole, string actionName)
            {
                //var per = tablatransacional(x => x.action == actionName && x.userRole == );

                //if (per != null) { }
               
                return userRole == "Admin";
            }
        }
    }
}
