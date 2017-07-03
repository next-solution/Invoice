using System;
using System.Threading.Tasks;
using Invoice.Infrastructure.DTO;

namespace Invoice.Infrastructure.Services
{
    public interface ICustomerService : IService
    {
         Task<CustomerDto> GetAsync(int tin);
         Task AddAsync(int tin, string name, string address, string zipcode, string city);
    }
}