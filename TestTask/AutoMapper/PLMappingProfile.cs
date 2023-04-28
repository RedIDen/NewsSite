using AutoMapper;
using TestTask.BusinessLayer.BusinessModels;
using TestTask.ViewModels;

namespace TestTask.BusinessLayer.AutoMapper
{
    public class PLMappingProfile : Profile
    {
        public PLMappingProfile()
        {
            this.CreateMap<CreateArticleViewModel, CreateArticleModel>()
                .ForMember(x => x.CreationTime, option => option.MapFrom(_ => DateTime.Now))
                .ForMember(x => x.ImageTitle, option => option.MapFrom(x => x.ImageFile.FileName))
                .ForMember(x => x.ImageFile, option => option.MapFrom(x => MapImageFile(x.ImageFile)));

            this.CreateMap<EditArticleModel, EditArticleViewModel>()
                .ForMember(x => x.ImageFile, option => option.Ignore());

            this.CreateMap<EditArticleViewModel, EditArticleModel>()
                .ForMember(x => x.ImageTitle, option => option.MapFrom(x => x.ImageFile.FileName))
                .ForMember(x => x.ImageFile, option => option.MapFrom(x => MapImageFile(x.ImageFile)));


            this.CreateMap<FullArticleModel, FullArticleViewModel>()
                .ForMember(x => x.CreationTime, option => option.MapFrom(x => MapDate(x.CreationTime) + $" {Resources.Resource.At} {x.CreationTime.ToShortTimeString()}"));
            
            this.CreateMap<ArticleListModel, ArticleListViewModel>()
                .ForMember(x => x.CreationTime, option => option.MapFrom(x => MapDate(x.CreationTime) + $" {Resources.Resource.At} {x.CreationTime.ToShortTimeString()}"));

            this.CreateMap<UserModel, UserViewModel>();
            this.CreateMap<RegisterViewModel, RegisterModel>();
        }

        private static string MapDate(DateTime date)
        {
            DateTime now = DateTime.Now;

            return date switch
            {
                _ when date.Year != now.Year => date.ToString("dd MMM yyyy"),
                _ when date.Month != now.Month => date.ToString("dd MMM"),
                _ when date.Day == now.Day => Resources.Resource.Today,
                _ when date.Day == now.Day - 1 => Resources.Resource.Yesterday,
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