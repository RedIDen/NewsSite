namespace TestTask.ViewModels
{
    public class EditArticleViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Text { get; set; }

        public IFormFile? ImageFile { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
