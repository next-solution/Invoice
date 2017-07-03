namespace Invoice.Infrastructure.Commands.Users
{
    public class CreateUser : ICommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string FullName { get; set; }
    }
}