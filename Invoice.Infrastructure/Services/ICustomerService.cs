using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Infrastructure.DTO;

namespace Invoice.Infrastructure.Services
{
    public interface ICustomerService : IService
    {
		Task<CustomerDto> GetAsync(Guid id);
		Task<CustomerDto> GetAsync(long nip);
        Task<CustomerDto> GetAsync(string email);
		Task<IEnumerable<CustomerDto>> GetByNameAsync(string name);
		Task AddAsync(long nip, string name, string address);
        Task RemoveAsync(Guid id);
    }
}