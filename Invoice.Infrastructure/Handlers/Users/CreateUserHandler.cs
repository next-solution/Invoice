using System;
using System.Threading.Tasks;
using Invoice.Infrastructure.Commands;
using Invoice.Infrastructure.Commands.Users;
using Invoice.Infrastructure.Services;

namespace Invoice.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;
        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(CreateUser command)
        {
            await _userService.RegisterAsync(command.Username, command.Password, command.FullName);
        }
    }
}