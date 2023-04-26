namespace TestTask.BusinessLayer.BusinessModels
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool IsActivated { get; set; }
    }
}
