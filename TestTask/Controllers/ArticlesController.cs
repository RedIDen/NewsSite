using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestTask.BusinessLayer.BusinessModels;
using TestTask.BusinessLayer.Interfaces;

namespace TestTask.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticlesService _service;
        private const int ArticlesPerPage = 6;

        public ArticlesController(IArticlesService service, IMapper mapper)
        {
            this._service = service;
            ViewBag.ArticlesPerPage = ArticlesPerPage;
        }

        // GET: Articles
        public async Task<IActionResult> Index(int? page)
        {
            page = page ?? 0;
            ViewBag.IsEndOfRecords = false;
            if (Request.Headers["x-requested-with"] == "XMLHttpRequest") // is ajax
            {
                var articles = await this._service.GetArticlesAsync(page.Value * ArticlesPerPage, ArticlesPerPage);
                ViewBag.IsEndOfRecords = articles.Count < ArticlesPerPage;
                return PartialView("_ArticleRow", articles);
            }
            else
            {
                ViewBag.Articles = await this._service.GetArticlesAsync(page.Value * ArticlesPerPage, ArticlesPerPage);
                return View("Index");
            }
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await this._service.GetArticleAsync(id.Value);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Subtitle,Text,ImageFile")] CreateArticleModel article)
        {
            if (ModelState.IsValid)
            {
                await this._service.CreateArticleAsync(article);
                return RedirectToAction(nameof(Index));
            }

            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await this._service.GetArticleToEditAsync(id.Value);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CreationTime,Title,Subtitle,Text,ImageFile")] EditArticleModel article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await this._service.EditArticleAsync(article);
                return RedirectToAction(nameof(Index));
            }

            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await this._service.GetArticleAsync(id.Value);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this._service.DeleteArticleAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
