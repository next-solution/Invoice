using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public DataInitializer(IUserService userService, ICustomerService customerService)
        {
            _userService = userService;
            _customerService = customerService;
        }

        public async Task SeedAsync()
        {
            var users = await _userService.GetAllAsync();
            if (users.Any())
            {
                Logger.Trace("Users are already initialized.");

                return;
            }
            Logger.Trace("Initializing users data...");
            for(var i = 1; i <= 10; i++)
            {
                var username = $"user{i}";
                await _userService.RegisterAsync(username, "password", "John Connor");

                var nip = 1111111111 + i;
                var customerName = $"customer{i}";
                await _customerService.AddAsync(nip, customerName, "address");
            }
            Logger.Trace("Users have been added.");
        }
    }
}
