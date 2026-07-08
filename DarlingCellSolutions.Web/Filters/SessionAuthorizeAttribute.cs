using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DarlingCellSolutions.Web.Filters;

public class SessionAuthorizeAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var usuario =
            context.HttpContext.Session.GetInt32("UsuarioId");

        if (usuario == null)
        {
            context.Result =
                new RedirectToActionResult(
                    "Index",
                    "Login",
                    null);
        }

        base.OnActionExecuting(context);
    }
}