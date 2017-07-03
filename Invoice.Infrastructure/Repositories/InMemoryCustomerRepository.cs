using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice.Core.Domain;
using Invoice.Core.Repositories;

namespace Invoice.Infrastructure.Repositories
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        
        private static ISet<Customer> _customers = new HashSet<Customer>()
        {
            new Customer(787367263, "John Rambo", "ul. Miodowa 2", "23-506", "Kraków"),
            new Customer(787367223, "John Rambo2", "ul. Miodowa 2", "23-506", "Kraków"),
            new Customer(787317263, "John Rambo3", "ul. Miodowa 2", "24-506", "Kraków")
        };


        public async Task AddAsync(Customer customer)
        {
            _customers.Add(customer);
            await Task.CompletedTask;
        }

        public async Task<Customer> GetAsync(Guid id)
            => await Task.FromResult(_customers.Single(x => x.Id == id));
        
        public async Task<Customer> GetAsync(int nip)
            => await Task.FromResult(_customers.Single(x => x.Nip == nip));

        public async Task<Customer> GetAsync(string email)
            => await Task.FromResult(_customers.Single(x => x.Email == email.ToLowerInvariant()));

        public async Task<IEnumerable<Customer>> GetAllAsync()
            => await Task.FromResult(_customers);

        public async Task RemoveAsync(Guid id)
        {
            var customer = await GetAsync(id);
            _customers.Remove(customer);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Customer customer)
        {
            await Task.CompletedTask;
        }
    }
}