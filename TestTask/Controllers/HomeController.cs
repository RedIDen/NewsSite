using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestTask.BusinessLayer.BusinessModels;
using TestTask.BusinessLayer.Interfaces;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        private IArticlesService _service;

        public HomeController(IArticlesService service)
        {
            this._service = service;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await this._service.GetAllArticlesAsync();
            return articles != null ?
                          View(articles) :
                          Problem("Entity set 'NewsSiteDbContext.Articles' is null.");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}