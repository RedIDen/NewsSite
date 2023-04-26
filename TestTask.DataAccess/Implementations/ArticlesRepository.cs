using Microsoft.EntityFrameworkCore;
using System.IO;
using TestTask.DataAccess.DataModels;
using TestTask.DataAccess.Interfaces;

namespace TestTask.DataAccess.Implementations
{
    public class ArticlesRepository : IArticlesRepository
    {
        private const string SubdirTemplate = "Article-";
        private const string ImagesDir = "/Images";
        private NewsSiteDbContext _context;


        public ArticlesRepository(NewsSiteDbContext context)
        {
            this._context = context;
        }

        public async Task<int> CreateArticleAsync(ArticleDataModel article)
        {
            var savedArticle = await this._context.Articles.AddAsync(article);
            await this._context.SaveChangesAsync();

            if (article.ImageFile != null)
            {
                string subdirPath = $"{SubdirTemplate}{savedArticle.Entity.Id}";

                var directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory() + $"/{ImagesDir}");

                if (!directoryInfo.Exists )
                {
                    directoryInfo.Create();
                }

                directoryInfo.CreateSubdirectory(subdirPath);

                string path = Path.Combine(directoryInfo + "/" + subdirPath + "/" + article.ImageTitle);

                using var fileStream = new FileStream(path, FileMode.Create);

                await fileStream.WriteAsync(article.ImageFile);
            }

            return savedArticle.Entity.Id;
        }

        public async Task<bool> DeleteArticleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ArticleDataModel>> GetLastArticlesAsync(int count)
        {
            var articles = await this._context.Articles.OrderByDescending(x => x.CreationTime).Take(count).ToListAsync();

            await LoadArticlesImages(articles);

            return articles;
        }

        public async Task<ArticleDataModel?> GetArticleAsync(int id)
        {
            var article = await this._context.Articles.FirstOrDefaultAsync(x => x.Id == id);

            await SetImageFile(article);

            return article;
        }

        public async Task<List<ArticleDataModel>> GetArticlesAsync(int offset, int limit)
        {
            var articles = await this._context.Articles.OrderByDescending(x => x.CreationTime).Skip(offset).Take(limit).ToListAsync();
            
            await LoadArticlesImages(articles);

            return articles;
        }

        public async Task<ArticleDataModel?> UpdateArticleAsync(ArticleDataModel article)
        {
            throw new NotImplementedException();
        }

        private async Task LoadArticlesImages(IEnumerable<ArticleDataModel> articles)
        {
            foreach (var article in articles)
            {
                await SetImageFile(article);
            }
        }

        private async Task SetImageFile(ArticleDataModel article)
        {
            var directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory() + $"/{ImagesDir}");

            string subdirPath = $"{SubdirTemplate}{article.Id}";
            string path = Path.Combine(directoryInfo + "/" + subdirPath + "/" + article.ImageTitle);

            article.ImageFile = await File.ReadAllBytesAsync(path);
        }
    }
}