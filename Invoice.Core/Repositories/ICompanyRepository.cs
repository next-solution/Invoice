using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Core.Domain;

namespace Invoice.Core.Repositories
{
    public interface ICompanyRepository : IRepository
    {
        Task<Company> GetAsync(long nip);
        Task<Company> GetAsync(string name);
        Task<IEnumerable<Company>> GetAllAsync();
        Task AddAsync(Company company);
        Task UpdateAsync(Company company);
        Task RemoveAsync(long nip);
    }
}