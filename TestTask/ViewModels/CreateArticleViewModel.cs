using System.ComponentModel.DataAnnotations;

namespace TestTask.ViewModels
{
    public class CreateArticleViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "TitleRequired")]
        [Display(Name = "Title", ResourceType = typeof(Resources.Resource))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "SubtitleRequired")]
        [Display(Name = "Subtitle", ResourceType = typeof(Resources.Resource))]
        public string Subtitle { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "TextRequired")]
        [Display(Name = "Text", ResourceType = typeof(Resources.Resource))]
        public string Text { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "ImageRequired")]
        [Display(Name = "Image", ResourceType = typeof(Resources.Resource))]
        public IFormFile ImageFile { get; set; }
    }
}
