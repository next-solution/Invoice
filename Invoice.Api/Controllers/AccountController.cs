using System.Threading.Tasks;
using Invoice.Infrastructure.Commands;
using Invoice.Infrastructure.Commands.Users;
using Invoice.Infrastructure.Handlers.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IJwtHandler _jwtHandler;

        public AccountController(ICommandDispatcher commandDispatcher,
            IJwtHandler jwtHandler) 
            : base(commandDispatcher)
        {
            _jwtHandler = jwtHandler;
        }

        [Authorize(Policy = "admin")]
        [HttpGet]
        [Route("token/{username}")]
        public IActionResult Get(string username)
        {
            var token = _jwtHandler.CreateToken(username, "admin");

            return Json(token);
        } 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]LoginUser command)
        {
            await _commandDispatcher.DispatchAsync(command);
            
            var token = _jwtHandler.CreateToken(command.Username, "admin");

            return Json(token);
        }

      /*  [HttpPut]
        [Route("password")]
        public async Task<IActionResult> Put([FromBody]ChangeUserPassword command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }        */
    }
}