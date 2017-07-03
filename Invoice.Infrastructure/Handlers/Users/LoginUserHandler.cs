using System;
using System.Threading.Tasks;
using Invoice.Infrastructure.Commands;
using Invoice.Infrastructure.Commands.Users;
using Invoice.Infrastructure.Services;

namespace Invoice.Infrastructure.Handlers.Users
{
    public class LoginUserHandler : ICommandHandler<LoginUser>
    {
        private readonly IUserService _userService;
        public LoginUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(LoginUser command)
        {
            await _userService.LoginAsync(command.Username, command.Password);
        }
    }
}