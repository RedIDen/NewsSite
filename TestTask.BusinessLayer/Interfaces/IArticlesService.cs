using TestTask.BusinessLayer.BusinessModels;

namespace TestTask.BusinessLayer.Interfaces
{
    public interface IArticlesService
    {
        public Task<List<ArticleListViewModel>> GetLastArticlesAsync();

        public Task<List<ArticleListViewModel>> GetArticlesAsync(int offset, int limit);

        public Task<FullArticleViewModel?> GetArticleAsync(int id);

        public Task<EditArticleModel?> GetArticleToEditAsync(int id);

        public Task<int> CreateArticleAsync(CreateArticleModel article);

        public Task<EditArticleModel?> EditArticleAsync(EditArticleModel article);

        public Task<bool> DeleteArticleAsync(int id);
    }
}
