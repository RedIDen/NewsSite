﻿using System.ComponentModel.DataAnnotations;

namespace TestTask.ViewModels
{
    public class EditArticleViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "TitleRequired")]
        [Display(Name = "Title", ResourceType = typeof(Resources.Resource))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "SubtitleRequired")]
        [Display(Name = "Subtitle", ResourceType = typeof(Resources.Resource))]
        public string Subtitle { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "TextRequired")]
        [Display(Name = "Text", ResourceType = typeof(Resources.Resource))]
        public string Text { get; set; }

        public IFormFile? ImageFile { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
