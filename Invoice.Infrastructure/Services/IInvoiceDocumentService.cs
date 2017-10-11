using Invoice.Core.Domain;
using Invoice.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Infrastructure.Services
{
    public interface IInvoiceDocumentService : IService
    {
        Task<IEnumerable<InvoiceDocumentDto>> GetAllAsync();
        Task<InvoiceDocumentDto> GetAsync(Guid id);
        Task<InvoiceDocumentDto> GetAsync(string number);
        Task CreateAsync(Guid companyId, Guid customerId, IEnumerable<Product> products);
        Task RemoveAsync(Guid id);
    }
}
