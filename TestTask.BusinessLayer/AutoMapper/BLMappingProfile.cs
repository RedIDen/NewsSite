using AutoMapper;
using TestTask.BusinessLayer.BusinessModels;
using TestTask.DataAccess.DataModels;

namespace TestTask.BusinessLayer.AutoMapper
{
    public class BLMappingProfile : Profile
    {
        public BLMappingProfile()
        {
            this.CreateMap<CreateArticleModel, ArticleDataModel>();

            this.CreateMap<ArticleDataModel, EditArticleModel>();
            this.CreateMap<EditArticleModel, ArticleDataModel>();

            this.CreateMap<ArticleDataModel, FullArticleModel>();
            this.CreateMap<ArticleDataModel, ArticleListModel>();

            this.CreateMap<UserDataModel, UserModel>();
            this.CreateMap<RegisterModel, UserDataModel>();
        }
    }
}