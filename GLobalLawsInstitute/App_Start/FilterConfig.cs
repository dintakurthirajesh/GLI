using System;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;

namespace GLobalLawsInstitute
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class NoDirectAccessAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (filterContext.HttpContext.Request.UrlReferrer == null ||
         filterContext.HttpContext.Request.Url.Host != filterContext.HttpContext.Request.UrlReferrer.Host)
                {
                    filterContext.Result = new RedirectToRouteResult(new
                                              RouteValueDictionary(new { controller = "Home", action = "Error" }));
                }
            }
        }

        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public class AjaxValidateAntiForgeryTokenAttribute : FilterAttribute, IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationContext filterContext)
            {
                try
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest()) // if it is ajax request.
                    {
                        this.ValidateRequestHeader(filterContext.HttpContext.Request); // run the validation.
                    }
                    else
                    {
                        AntiForgery.Validate();
                    }
                }
                catch (HttpAntiForgeryException e)
                {
                    throw new HttpAntiForgeryException("Anti forgery token not found");
                }
            }
            private void ValidateRequestHeader(HttpRequestBase request)
            {
                string cookieToken = string.Empty;
                string formToken = string.Empty;
                string tokenValue = request.Headers["VerificationToken"]; // read the header key and validate the tokens.
                if (!string.IsNullOrEmpty(tokenValue))
                {
                    string[] tokens = tokenValue.Split(',');
                    if (tokens.Length == 2)
                    {
                        cookieToken = tokens[0].Trim();
                        formToken = tokens[1].Trim();
                    }
                }

                AntiForgery.Validate(cookieToken, formToken); // this validates the request token.
            }
        }
    }
}
