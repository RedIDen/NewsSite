﻿namespace TestTask.BusinessLayer.BusinessModels
{
    public class CreateArticleModel
    {
        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Text { get; set; }

        public string ImageTitle { get; set; }

        public byte[] ImageFile { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
