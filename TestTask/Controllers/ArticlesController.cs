﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestTask.BusinessLayer.BusinessModels;
using TestTask.BusinessLayer.Interfaces;

namespace TestTask.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticlesService _service;

        public ArticlesController(IArticlesService service, IMapper mapper)
        {
            this._service = service;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            var articles =await this._service.GetAllArticlesAsync();
            return articles != null ? 
                          View(articles) :
                          Problem("Entity set 'NewsSiteDbContext.Articles' is null.");
        }

        //// GET: Articles/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Articles == null)
        //    {
        //        return NotFound();
        //    }

        //    var articleDataModel = await _context.Articles
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (articleDataModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(articleDataModel);
        //}

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

        //// GET: Articles/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Articles == null)
        //    {
        //        return NotFound();
        //    }

        //    var articleDataModel = await _context.Articles.FindAsync(id);
        //    if (articleDataModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(articleDataModel);
        //}

        //// POST: Articles/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,CreationTime,Title,Subtitle,Text,ImageTitle")] ArticleDataModel articleDataModel)
        //{
        //    if (id != articleDataModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(articleDataModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ArticleDataModelExists(articleDataModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(articleDataModel);
        //}

        //// GET: Articles/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Articles == null)
        //    {
        //        return NotFound();
        //    }

        //    var articleDataModel = await _context.Articles
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (articleDataModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(articleDataModel);
        //}

        //// POST: Articles/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Articles == null)
        //    {
        //        return Problem("Entity set 'NewsSiteDbContext.Articles'  is null.");
        //    }
        //    var articleDataModel = await _context.Articles.FindAsync(id);
        //    if (articleDataModel != null)
        //    {
        //        _context.Articles.Remove(articleDataModel);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ArticleDataModelExists(int id)
        //{
        //  return (_context.Articles?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}