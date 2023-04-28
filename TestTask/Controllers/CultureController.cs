using Microsoft.AspNetCore.Mvc;
using TestTask.Filters;

namespace TestTask.Controllers
{
    public class CultureController : Controller
    {
        public ActionResult ChangeCulture(string lang)
        {
            if (!CultureAttribute.Cultures.Contains(lang))
            {
                lang = "ru-RU";
            }

            Response.Cookies.Append("lang", lang);

            string returnUrl = Request.Headers["Referer"].ToString();
            return Redirect(returnUrl);
        }
    }
}
