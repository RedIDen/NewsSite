using System.ComponentModel.DataAnnotations;

namespace TestTask.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "EmailRequiered")]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resource))]
        public string Login { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "PasswordRequired")]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resource))]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
