namespace TestTask.ViewModels
{
    public class CreateArticleViewModel
    {
        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Text { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
