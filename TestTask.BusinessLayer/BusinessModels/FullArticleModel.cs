﻿namespace TestTask.BusinessLayer.BusinessModels
{
    public class FullArticleModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Text { get; set; }

        public byte[] ImageFile { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
