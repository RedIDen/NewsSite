namespace TestTask.BusinessLayer.BusinessModels
{
    public class FullArticleViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Text { get; set; }

        public byte[] ImageFile { get; set; }

        public string CreationTime { get; set; }
    }
}
