using Microsoft.AspNetCore.Mvc.Filters;
using System.Globalization;

namespace TestTask.Filters
{
    public class CultureAttribute : Attribute, IActionFilter
    {
        public static readonly List<string> Cultures = new List<string>() { "ru-RU", "en-US", "be-BY" };

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string cultureName;
            var cultureCookie = context.HttpContext.Request.Cookies["lang"];

            if (cultureCookie != null)
            {
                cultureName = cultureCookie;
            }
            else
            {
                cultureName = "ru-RU";
            }

            if (!Cultures.Contains(cultureName))
            {
                cultureName = "ru-RU";
            }

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);
        }
    }
}
