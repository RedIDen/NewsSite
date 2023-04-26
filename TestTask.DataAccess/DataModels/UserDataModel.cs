namespace TestTask.DataAccess.DataModels
{
    public class UserDataModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool IsActivated { get; set; }
    }
}
