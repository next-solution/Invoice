using System.Linq;
using System.Threading.Tasks;
using Invoice.Infrastructure.Commands;
using Invoice.Infrastructure.Commands.Customers;
using Invoice.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace Invoice.Api.Controllers
{
    //[Authorize(Policy = "admin")]
    [Route("[controller]")]
    public class CustomersController : ApiControllerBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService,
            ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _customerService = customerService;
        }

        // GET api/values/5
        [HttpGet("nip/{nip}")]
        public async Task<IActionResult> GetByNip (string nip)
        {
            Logger.Info($"Getting customer with NIP: {nip}.");
            var customer = await _customerService.GetByNipAsync(nip);
            if(customer == null)
            {
                return NotFound();
            }
            return Json(customer);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            Logger.Info($"Getting customers with name: {name}");
            var customer = await _customerService.GetByNameAsync(name);
            if(!customer.Any())
            {
                return NotFound();
            }
            return Json(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateCustomer command)
        {
            await _commandDispatcher.DispatchAsync(command);
            
            return Created($"users/{command.Name}", new object());
        }
    }
}
