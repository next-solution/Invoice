using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Invoice.Core.Domain;
using Invoice.Core.Repositories;
using Invoice.Infrastructure.DTO;
using NLog;

namespace Invoice.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


		public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDto> GetAsync(Guid id)
        {
            var customer = await _customerRepository.GetAsync(id);
            return _mapper.Map<Customer, CustomerDto>(customer);
        }

        public async Task<CustomerDto> GetByNipAsync(string nip)
        {
            var customer = await _customerRepository.GetByNipAsync(nip);
            return _mapper.Map<Customer, CustomerDto>(customer);
        }

        public async Task<CustomerDto> GetByEmailAsync(string email)
        {
            var customer = await _customerRepository.GetByEmailAsync(email);
            return _mapper.Map<Customer, CustomerDto>(customer);
        }

        public async Task<IEnumerable<CustomerDto>> GetByNameAsync(string name)
        {
            var customer = await _customerRepository.GetByNameAsync(name);
            return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customer);
        }

        public async Task AddAsync(string nip, string name, string address)
        {
            var customer = await _customerRepository.GetByNipAsync(nip);
            if (customer != null)
            {
                throw new Exception ($"Customer with NIP: '{nip}' already exists");
            }
            customer = new Customer(nip, name, address);
            await _customerRepository.AddAsync(customer);
        }

        public async Task RemoveAsync(Guid id)
        {
            var customer = await _customerRepository.GetAsync(id);
            if(customer == null)
            {
                throw new Exception($"Customer with Guid: '{id}' does not already exist");
            }
            await _customerRepository.RemoveAsync(id);
        }
    }
}