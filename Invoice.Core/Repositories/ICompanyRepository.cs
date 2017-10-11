using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Core.Domain;

namespace Invoice.Core.Repositories
{
    public interface ICompanyRepository : IRepository
    {
        Task<Company> GetByNipAsync(string nip);
        Task<Company> GetByNameAsync(string name);
        Task<IEnumerable<Company>> GetAllAsync();
        Task AddAsync(Company company);
        Task UpdateAsync(Company company);
        Task RemoveAsync(string nip);
    }
}