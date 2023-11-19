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
                        var userIdFromRequest = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                        if (userIdFromToken != userIdFromRequest)
                        {
                            context.Result = new ForbidResult(); // Devolver un código de estado 'Forbidden'
                            return;
                        }

                        // Puedes agregar la información del usuario al contexto si es necesario
                        context.HttpContext.Items["UserId"] = userIdFromToken;
               

                        // Continuar con la ejecución normal de la acción del controlador
                        return;
                    }
                }

                // Si el token no es válido, devolver un código de estado no autorizado
                context.Result = new UnauthorizedResult();
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                // Obtener el nombre de la acción ejecutada
                var actionName = context.ActionDescriptor.RouteValues["action"];

                // Verificar si el rol tiene permiso para la acción en una tabla o sistema de permisos
                var userId = context.HttpContext.Items["UserId"] as string;
                var userRole = context.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;

                if (!HasPermission(userId, userRole, actionName))
                {
                    context.Result = new ForbidResult(); // Devolver un código de estado 'Forbidden'
                }
            }

            public void OnActionExecuted(ActionExecutedContext context)
            {
                // Lógica posterior a la ejecución de la acción (opcional)
            }

            private bool HasPermission(string userId, string userRole, string actionName)
            {
                // Implementa lógica para verificar si el rol tiene permiso para la acción
                // Puedes consultar una tabla de permisos, base de datos, etc.

                // Ejemplo: Validar si el usuario tiene el rol "Admin" para cualquier acción
                return userRole == "Admin";
            }
        }
    }
}
