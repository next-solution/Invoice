using System.Threading.Tasks;
using Invoice.Infrastructure.Commands;
using Invoice.Infrastructure.Commands.Customers;
using Invoice.Infrastructure.Services;

namespace Invoice.Infrastructure.Handlers.Customers
{
    public class CreateCustomerHandler : ICommandHandler<CreateCustomer>
    {
        private readonly ICustomerService _customerService;
        public CreateCustomerHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task HandleAsync(CreateCustomer command)
        {
            await _customerService.AddAsync(command.Nip, command.Name, 
                command.Address);
        }
    }
}