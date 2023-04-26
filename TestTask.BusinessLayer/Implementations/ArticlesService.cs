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

        public async Task<List<ArticleViewModel>> GetAllArticlesAsync()
        {
            var result = this._mapper.Map<List<ArticleViewModel>>(await this._repository.GetAllArticlesAsync());
            return result;
        }

        public async Task<ArticleViewModel?> GetArticleAsync(int id)
        {
            var result = this._mapper.Map<ArticleViewModel?>(await this._repository.GetArticleAsync(id));
            return result;
        }

        public async Task<List<ArticleViewModel>> GetArticlesAsync(int offset, int limit)
        {
            var result = this._mapper.Map<List<ArticleViewModel>>(await this._repository.GetArticlesAsync(offset, limit));
            return result;
        }

        public async Task<ArticleViewModel?> UpdateArticleAsync(ArticleViewModel article)
        {
            var articleDataModel = this._mapper.Map<ArticleDataModel>(article);
            var result = this._mapper.Map<ArticleViewModel?>(await this._repository.UpdateArticleAsync(articleDataModel));
            return result;
        }
    }
}
