using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab6.Filters;

public class AuthorizedFilter : Attribute, IAuthorizationFilter
{
	public void OnAuthorization(AuthorizationFilterContext context)
	{
		var userId = context.HttpContext.Session.GetInt32("User");

		if (userId is null)
		{
			context.Result = new RedirectToRouteResult(
				new RouteValueDictionary {
					{ "controller", "Authorization" },
					{ "action", "Index" }
				}
			);
		}
	}
}
