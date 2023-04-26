using TestTask.BusinessLayer.BusinessModels;

namespace TestTask.BusinessLayer.Interfaces
{
    public interface IArticlesService
    {
        public Task<List<ArticleViewModel>> GetAllArticlesAsync();

        public Task<List<ArticleViewModel>> GetArticlesAsync(int offset, int limit);

        public Task<ArticleViewModel?> GetArticleAsync(int id);

        public Task<int> CreateArticleAsync(CreateArticleModel article);

        public Task<ArticleViewModel?> UpdateArticleAsync(ArticleViewModel article);

        public Task<bool> DeleteArticleAsync(int id);
    }
}
