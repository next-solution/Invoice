using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Invoice.Core.Domain;

namespace Invoice.Core.Repositories
{
    public interface IInvoiceDocumentRepository : IRepository
    {
        Task<InvoiceDocument> GetAsync(Guid id);
        Task<InvoiceDocument> GetAsync(string number);
        Task<IEnumerable<InvoiceDocument>> GetByCustomerAsync(Guid customerId);
        Task<IEnumerable<InvoiceDocument>> GetAllAsync();
        Task AddAsync(InvoiceDocument invoiceDocument);
        Task UpdateAsync(InvoiceDocument invoiceDocument);
        Task RemoveAsync(Guid id);
        Task RemoveASync(string number);
    }
}
