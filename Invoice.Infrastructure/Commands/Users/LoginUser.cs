namespace Invoice.Infrastructure.Commands.Users
{
    public class LoginUser : ICommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}