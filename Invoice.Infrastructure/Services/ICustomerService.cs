using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Infrastructure.DTO;

namespace Invoice.Infrastructure.Services
{
    public interface ICustomerService : IService
    {
		Task<CustomerDto> GetAsync(Guid id);
		Task<CustomerDto> GetByNipAsync(string nip);
        Task<CustomerDto> GetByEmailAsync(string email);
		Task<IEnumerable<CustomerDto>> GetByNameAsync(string name);
		Task AddAsync(string nip, string name, string address);
        Task RemoveAsync(Guid id);
    }
}