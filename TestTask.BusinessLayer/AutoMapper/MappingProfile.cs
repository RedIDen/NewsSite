using AutoMapper;
using Microsoft.AspNetCore.Http;
using TestTask.BusinessLayer.BusinessModels;
using TestTask.DataAccess.DataModels;

namespace TestTask.BusinessLayer.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<CreateArticleModel, ArticleDataModel>()
                .ForMember(x => x.CreationTime, option => option.MapFrom(_ => DateTime.Now))
                .ForMember(x => x.ImageTitle, option => option.MapFrom(x => x.ImageFile.FileName))
                .ForMember(x => x.ImageFile, option => option.MapFrom(x => MapImageFile(x.ImageFile)));

            this.CreateMap<ArticleDataModel, FullArticleViewModel>()
                .ForMember(x => x.CreationTime, option => option.MapFrom(x => MapDate(x.CreationTime) + $" в {x.CreationTime.ToShortTimeString()}"));
            this.CreateMap<ArticleDataModel, ArticleListViewModel>()
                .ForMember(x => x.CreationTime, option => option.MapFrom(x => MapDate(x.CreationTime) + $" в {x.CreationTime.ToShortTimeString()}")); 

            this.CreateMap<UserDataModel, UserModel>();
            this.CreateMap<RegisterModel, UserDataModel>();
        }

        private static string MapDate(DateTime date)
        {
            DateTime now = DateTime.Now;

            return date switch
            {
                _ when date.Year != now.Year => date.ToString("dd MMM yyyy"),
                _ when date.Month != now.Month => date.ToString("dd MMM"),
                _ when date.Day == now.Day => "Сегодня",
                _ when date.Day == now.Day - 1 => "Вчера",
                _ => date.ToString("dd MMM"),
            };
        }

        private byte[]? MapImageFile(IFormFile file)
        {
            if (file == null)
            {
                return null;
            }

            using var stream = new MemoryStream();
            file.CopyTo(stream);
            return stream.ToArray();
        }
    }
}
