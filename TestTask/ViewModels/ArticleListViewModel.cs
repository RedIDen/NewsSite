namespace TestTask.ViewModels
{
    public class ArticleListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public byte[]? ImageFile { get; set; }

        public string CreationTime { get; set; }
    }
}
