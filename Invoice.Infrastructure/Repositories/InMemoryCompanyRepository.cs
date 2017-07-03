using System;
using System.Threading.Tasks;
using Invoice.Core.Domain;
using Invoice.Core.Repositories;

namespace Invoice.Infrastructure.Repositories
{
    public class InMemoryCompanyRepository : ICompanyRepository
    {
        Company company = new Company(1234567890, "Firma", "ul. Dowolna 12", "12-330", "Miasto", "email@email.com");
        public async Task<Company> GetAsync()
            => await Task.FromResult(company);

        public async Task UpdateAsync()
        {
            await Task.CompletedTask;
        }
    }
}