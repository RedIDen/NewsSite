using System.ComponentModel.DataAnnotations;

namespace TestTask.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "NameRequired")]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "WrongNameLength", MinimumLength = 2)]
        [Display(Name = "Name", ResourceType = typeof(Resources.Resource))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "EmailRequiered")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "InvalidEmail")]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "WrongEmailLenght", MinimumLength = 5)]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resource))]
        public string Login { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "PasswordRequired")]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "WrongPasswordLenght", MinimumLength = 5)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resource))]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "RepeatPasswordRequired")]
        [Display(Name = "RepeatPassword", ResourceType = typeof(Resources.Resource))]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "WrongPassword")]
        public string ConfirmPassword { get; set; }
    }
}
