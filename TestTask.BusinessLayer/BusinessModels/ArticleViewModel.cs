﻿namespace TestTask.BusinessLayer.BusinessModels
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
