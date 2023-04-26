using Microsoft.EntityFrameworkCore;
using TestTask.DataAccess.DataModels;
using TestTask.DataAccess.Interfaces;

namespace TestTask.DataAccess.Implementations
{
    public class ArticlesRepository : IArticlesRepository
    {
        private NewsSiteDbContext _context;

        public ArticlesRepository(NewsSiteDbContext context)
        {
            this._context = context;
        }

        public async Task<int> CreateArticleAsync(ArticleDataModel article)
        {
            var savedArticle = await this._context.Articles.AddAsync(article);
            await this._context.SaveChangesAsync();

            return savedArticle.Entity.Id;
        }

        public async Task<bool> DeleteArticleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ArticleDataModel>> GetAllArticlesAsync()
        {
            return await this._context.Articles.ToListAsync();
        }

        public async Task<ArticleDataModel?> GetArticleAsync(int id)
        {
            return await this._context.Articles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ArticleDataModel>> GetArticlesAsync(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task<ArticleDataModel?> UpdateArticleAsync(ArticleDataModel article)
        {
            throw new NotImplementedException();
        }
    }
}