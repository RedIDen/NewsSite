using TestTask.BusinessLayer.BusinessModels;

namespace TestTask.BusinessLayer.Interfaces
{
    public interface IArticlesService
    {
        public Task<List<ArticleListModel>> GetLastArticlesAsync();

        public Task<List<ArticleListModel>> GetArticlesAsync(int offset, int limit);

        public Task<FullArticleModel?> GetArticleAsync(int id);

        public Task<EditArticleModel?> GetArticleToEditAsync(int id);

        public Task<int> CreateArticleAsync(CreateArticleModel article);

        public Task<EditArticleModel?> EditArticleAsync(EditArticleModel article);

        public Task<bool> DeleteArticleAsync(int id);
    }
}
