using Invoice.Core.Domain;
using Invoice.Core.Repositories;
using Invoice.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository, ISqlRepository
    {
        private readonly InvoiceContext _context;

        public CustomerRepository(InvoiceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
            => await _context.Customers.ToListAsync();

        public async Task<Customer> GetAsync(Guid id)
            => await _context.Customers.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<Customer> GetByNipAsync(string nip)
            => await _context.Customers.SingleOrDefaultAsync(x => x.Nip == nip);

        public async Task<Customer> GetByEmailAsync(string email)
            => await _context.Customers.SingleOrDefaultAsync(x => x.Email == email);

        public async Task<IEnumerable<Customer>> GetByNameAsync(string name)
            => await Task.FromResult(_context.Customers.Where(x => x.Name.Contains(name)));

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var customer = await GetAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
