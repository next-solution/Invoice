using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice.Core.Domain;
using Invoice.Core.Repositories;
using Invoice.Infrastructure.Settings;

namespace Invoice.Infrastructure.Repositories
{
    public class InMemoryCompanyRepository : ICompanyRepository
    {
        static private readonly CompanySettings _companySettings = new CompanySettings();

        private static ISet<Company> _company = new HashSet<Company>()
        {
            new Company(_companySettings.Nip, _companySettings.Name,
            _companySettings.Address, _companySettings.Email)
        };
		
        public async Task<IEnumerable<Company>> GetAllAsync()
        	=> await Task.FromResult(_company);

		public async Task<Company> GetAsync(long nip)
			=> await Task.FromResult(_company.Single(x => x.Nip == nip));

		public async Task<Company> GetAsync(string name)
			=> await Task.FromResult(_company.Single(x => x.Name == name));

		public async Task AddAsync(Company company)
		{
			_company.Add(company);
            await Task.CompletedTask;
		}

		public async Task RemoveAsync(long nip)
		{
			var company = await GetAsync(nip);
			_company.Remove(company);
			await Task.CompletedTask;
		}

		public async Task UpdateAsync(Company company)
		{
			await RemoveAsync(company.Nip);
			await AddAsync(company);
			await Task.CompletedTask;
		}
    }
}