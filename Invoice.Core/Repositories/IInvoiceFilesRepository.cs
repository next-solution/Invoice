using System;
using System.Threading.Tasks;

namespace Invoice.Core.Repositories
{
    public interface IInvoiceFilesRepository : IRepository
    {
        Task<string> GetUrlAsync (Guid Id);
        Task UpdateAsync (Guid Id);
    }
}