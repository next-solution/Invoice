using System.Threading.Tasks;
using Invoice.Core.Domain;

namespace Invoice.Core.Repositories
{
    public interface ICompanyRepository : IRepository
    {
        Task<Company> GetAsync();
        Task UpdateAsync();
    }
}