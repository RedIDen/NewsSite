using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestTask.BusinessLayer.Interfaces;
using TestTask.ViewModels;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticlesService _service;
        private readonly IMapper _mapper;

        public HomeController(IArticlesService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var articles = this._mapper.Map<List<ArticleListViewModel>>(await this._service.GetLastArticlesAsync());
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