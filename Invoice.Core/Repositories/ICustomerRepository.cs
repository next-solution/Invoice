using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Core.Domain;

namespace Invoice.Core.Repositories
{
    public interface ICustomerRepository : IRepository
    {
		Task<Customer> GetAsync(Guid id);
		Task<Customer> GetByNipAsync(string nip);
        Task<Customer> GetByEmailAsync(string email);
        Task<IEnumerable<Customer>> GetByNameAsync(string name);
		Task<IEnumerable<Customer>> GetAllAsync();
		Task AddAsync (Customer customer);
		Task UpdateAsync (Customer customer);
		Task RemoveAsync (Guid id);
    }
}