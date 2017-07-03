using System;
using System.Threading.Tasks;
using AutoMapper;
using Invoice.Core.Domain;
using Invoice.Core.Repositories;
using Invoice.Infrastructure.DTO;

namespace Invoice.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<CustomerDto> GetAsync(int nip)
        {
            var customer = await _customerRepository.GetAsync(nip);
            
            return _mapper.Map<Customer, CustomerDto>(customer);
        }
        public async Task AddAsync(int nip, string name, string address, string zipcode, string city)
        {
            var customer = await _customerRepository.GetAsync(nip);
            if (customer != null)
            {
                throw new Exception ($"Customer with NIP: '{nip}' already exists");
            }
            customer = new Customer(nip, name, address, zipcode, city);
            await _customerRepository.AddAsync(customer);
        }
    }
}