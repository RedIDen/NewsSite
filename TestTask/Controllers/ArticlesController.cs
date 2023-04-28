using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestTask.BusinessLayer.BusinessModels;
using TestTask.BusinessLayer.Interfaces;
using TestTask.ViewModels;

namespace TestTask.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticlesService _service;
        private readonly IMapper _mapper;
        private const int ArticlesPerPage = 6;

        public ArticlesController(IArticlesService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
            ViewBag.ArticlesPerPage = ArticlesPerPage;
        }

        // GET: Articles
        public async Task<IActionResult> Index(int? page)
        {
            page ??= 0;
            ViewBag.IsEndOfRecords = false;
            var articles = this._mapper.Map<List<ArticleListViewModel>>(await this._service.GetArticlesAsync(page.Value * ArticlesPerPage, ArticlesPerPage));

            if (Request.Headers["x-requested-with"] == "XMLHttpRequest") // is ajax
            {
                ViewBag.IsEndOfRecords = articles.Count < ArticlesPerPage;
                return PartialView("_ArticleRow", articles);
            }

            ViewBag.Articles = articles;
            return View("Index");
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = this._mapper.Map<FullArticleViewModel>(await this._service.GetArticleAsync(id.Value));

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
        public async Task<IActionResult> Create([Bind("Title,Subtitle,Text,ImageFile")] CreateArticleViewModel article)
        {
            if (ModelState.IsValid)
            {
                await this._service.CreateArticleAsync(this._mapper.Map<CreateArticleModel>(article));
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

            var article = this._mapper.Map<EditArticleViewModel>(await this._service.GetArticleToEditAsync(id.Value));

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CreationTime,Title,Subtitle,Text,ImageFile")] EditArticleViewModel article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await this._service.EditArticleAsync(this._mapper.Map<EditArticleModel>(article));
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

            var article = this._mapper.Map<FullArticleViewModel>(await this._service.GetArticleAsync(id.Value));

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
