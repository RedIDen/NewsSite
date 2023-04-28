using System.ComponentModel.DataAnnotations;

namespace TestTask.ViewModels
{
    public class FullArticleViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Resources.Resource))]
        public string Title { get; set; }

        [Display(Name = "Subtitle", ResourceType = typeof(Resources.Resource))]
        public string Subtitle { get; set; }

        [Display(Name = "Text", ResourceType = typeof(Resources.Resource))]
        public string Text { get; set; }

        [Display(Name = "Image", ResourceType = typeof(Resources.Resource))]
        public byte[] ImageFile { get; set; }

        [Display(Name = "CreationTime", ResourceType = typeof(Resources.Resource))]
        public string CreationTime { get; set; }
    }
}
