namespace TestTask.BusinessLayer.BusinessModels
{
    public class ArticleListModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public byte[]? ImageFile { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
