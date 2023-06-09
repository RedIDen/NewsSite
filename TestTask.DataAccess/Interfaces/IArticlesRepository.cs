﻿using TestTask.DataAccess.DataModels;

namespace TestTask.DataAccess.Interfaces
{
    public interface IArticlesRepository
    {
        public Task<List<ArticleDataModel>> GetLastArticlesAsync(int count);

        public Task<List<ArticleDataModel>> GetArticlesAsync(int offset, int limit);

        public Task<ArticleDataModel?> GetArticleAsync(int id);

        public Task<int> CreateArticleAsync(ArticleDataModel article);

        public Task<ArticleDataModel?> EditArticleAsync(ArticleDataModel article);

        public Task<bool> DeleteArticleAsync(int id);
    }
}
