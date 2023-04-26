namespace TestTask.DataAccess.DataModels
{
    public class ArticleDataModel
    {
        public int Id { get; set; }

        public DateTime CreationTime { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Text { get; set; }

        public string ImageTitle { get; set; }
    }
}
