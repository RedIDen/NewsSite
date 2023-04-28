using Microsoft.EntityFrameworkCore;
using TestTask.DataAccess.DataModels;
using TestTask.DataAccess.Interfaces;

namespace TestTask.DataAccess.Implementations
{
    public class ArticlesRepository : IArticlesRepository
    {
        private const string SubdirTemplate = "Article-";
        private const string ImagesDir = "/Images";
        private readonly DirectoryInfo _imagesDirectotyInfo = new DirectoryInfo(Directory.GetCurrentDirectory() + $"/{ImagesDir}");
        private readonly NewsSiteDbContext _context;

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
                await this.SaveArticleImage(article, savedArticle.Entity.Id);
            }

            return savedArticle.Entity.Id;
        }

        public async Task<bool> DeleteArticleAsync(int id)
        {
            ArticleDataModel article = new ArticleDataModel() { Id = id };
            this._context.Articles.Attach(article);
            var result = this._context.Articles.Remove(article);

            this.DeleteArticleImage(id, keepFolder: false);

            await this._context.SaveChangesAsync();

            return result != null;
        }

        public async Task<List<ArticleDataModel>> GetLastArticlesAsync(int count)
        {
            var articles = await this._context.Articles.OrderByDescending(x => x.CreationTime).Take(count).ToListAsync();

            await this.LoadArticlesImages(articles);

            return articles;
        }

        public async Task<ArticleDataModel?> GetArticleAsync(int id)
        {
            var article = await this._context.Articles.FirstOrDefaultAsync(x => x.Id == id);

            if (article == null)
            {
                return article;
            }

            await this.SetImageFile(article);

            return article;
        }

        public async Task<List<ArticleDataModel>> GetArticlesAsync(int offset, int limit)
        {
            var articles = await this._context.Articles.OrderByDescending(x => x.CreationTime).Skip(offset).Take(limit).ToListAsync();

            await this.LoadArticlesImages(articles);

            return articles;
        }

        public async Task<ArticleDataModel?> EditArticleAsync(ArticleDataModel article)
        {
            bool isImageChanged = article.ImageTitle != null && article.ImageFile.Length != 0;

            var originalArticle = await this.GetArticleAsync(article.Id);

            originalArticle.Title = article.Title;
            originalArticle.Subtitle = article.Subtitle;
            originalArticle.Text = article.Text;

            if(isImageChanged)
            {
                this.DeleteArticleImage(originalArticle.Id, keepFolder: true);

                originalArticle.ImageTitle = article.ImageTitle!;
                originalArticle.ImageFile = article.ImageFile;

                await this.SaveArticleImage(originalArticle, originalArticle.Id);
            }

            await this._context.SaveChangesAsync();

            return article;
        }

        private async Task LoadArticlesImages(IEnumerable<ArticleDataModel> articles)
        {
            foreach (var article in articles)
            {
                await this.SetImageFile(article);
            }
        }

        private async Task SetImageFile(ArticleDataModel article)
        {
            string subdirPath = $"{SubdirTemplate}{article.Id}";
            string path = Path.Combine(this._imagesDirectotyInfo + "/" + subdirPath + "/" + article.ImageTitle);

            article.ImageFile = await File.ReadAllBytesAsync(path);
        }

        private async Task<FileStream> SaveArticleImage(ArticleDataModel article, int id)
        {
            string subdirPath = $"{SubdirTemplate}{id}";

            if (!this._imagesDirectotyInfo.Exists)
            {
                this._imagesDirectotyInfo.Create();
            }

            this._imagesDirectotyInfo.CreateSubdirectory(subdirPath);

            string path = Path.Combine(this._imagesDirectotyInfo + "/" + subdirPath + "/" + article.ImageTitle);
            using var fileStream = new FileStream(path, FileMode.Create);

            await fileStream.WriteAsync(article.ImageFile);
            return fileStream;
        }

        private void DeleteArticleImage(int id, bool keepFolder)
        {
            string subdirPath = $"{SubdirTemplate}{id}";
            string path = Path.Combine(this._imagesDirectotyInfo + "/" + subdirPath + "/");

            DirectoryInfo directory = new DirectoryInfo(path);

            foreach (FileInfo file in directory.EnumerateFiles())
            {
                file.Delete();
            }

            if (!keepFolder)
            { 
                directory.Delete();
            }
        }
    }
}