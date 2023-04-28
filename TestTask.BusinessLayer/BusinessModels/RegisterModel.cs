using System.ComponentModel.DataAnnotations;

namespace TestTask.BusinessLayer.BusinessModels
{
    public class RegisterModel
    {
        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
