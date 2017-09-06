using System.Threading.Tasks;
using Invoice.Infrastructure.Commands;
using Invoice.Infrastructure.Commands.Users;
using Invoice.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace Invoice.Api.Controllers
{
    //[Authorize(Policy = "admin")]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IUserService _userService;

        public UsersController(IUserService userService, 
            ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _userService = userService;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Logger.Info($"Getting all users...");
            var users = await _userService.GetAllAsync();
            if (users == null)
            {
                return NotFound();
            }
            return Json(users);
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> Get (string username)
        {         
            Logger.Info($"Getting user: {username}");
            var user = await _userService.GetAsync(username);
            if(user == null)
            {
                return NotFound();
            }
            return Json(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await _commandDispatcher.DispatchAsync(command);
            
            return Created($"users/{command.Username}", new object());
        }
      
    }
}
