using AutoMapper;
using TestTask.BusinessLayer.BusinessModels;
using TestTask.BusinessLayer.Interfaces;
using TestTask.DataAccess.DataModels;
using TestTask.DataAccess.Interfaces;

namespace TestTask.BusinessLayer.Implementations
{
    public class ArticlesService : IArticlesService
    {
        private readonly IArticlesRepository _repository;
        private readonly IMapper _mapper;

        public ArticlesService(IArticlesRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<int> CreateArticleAsync(CreateArticleModel article)
        {
            var articleDataModel = this._mapper.Map<ArticleDataModel>(article);
            int result = await this._repository.CreateArticleAsync(articleDataModel);
            return result;
        }

        public async Task<bool> DeleteArticleAsync(int id)
        {
            var result = await this._repository.DeleteArticleAsync(id);
            return result;
        }

        public async Task<List<ArticleListViewModel>> GetLastArticlesAsync()
        {
            const int count = 4;
            var result = this._mapper.Map<List<ArticleListViewModel>>(await this._repository.GetLastArticlesAsync(count));
            return result;
        }

        public async Task<FullArticleViewModel?> GetArticleAsync(int id)
        {
            var result = this._mapper.Map<FullArticleViewModel?>(await this._repository.GetArticleAsync(id));
            return result;
        }

        public async Task<EditArticleModel?> GetArticleToEditAsync(int id)
        {
            var result = this._mapper.Map<EditArticleModel?>(await this._repository.GetArticleAsync(id));
            return result;
        }

        public async Task<List<ArticleListViewModel>> GetArticlesAsync(int offset, int limit)
        {
            var result = this._mapper.Map<List<ArticleListViewModel>>(await this._repository.GetArticlesAsync(offset, limit));
            return result;
        }

        public async Task<EditArticleModel?> EditArticleAsync(EditArticleModel article)
        {
            var articleDataModel = this._mapper.Map<ArticleDataModel>(article);
            var result = this._mapper.Map<EditArticleModel?>(await this._repository.EditArticleAsync(articleDataModel));
            return result;
        }
    }
}
