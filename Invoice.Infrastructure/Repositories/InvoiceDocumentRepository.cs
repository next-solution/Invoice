using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Invoice.Core.Domain;
using Invoice.Core.Repositories;
using Invoice.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Invoice.Infrastructure.Repositories
{
    public class InvoiceDocumentRepository : IInvoiceDocumentRepository
    {
        private readonly InvoiceContext _context;

        public InvoiceDocumentRepository(InvoiceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InvoiceDocument>> GetAllAsync()
            => await _context.InvoiceDocuments.ToListAsync();

        public async Task<InvoiceDocument> GetAsync(Guid id)
            => await _context.InvoiceDocuments.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<InvoiceDocument> GetAsync(string number)
            => await _context.InvoiceDocuments.FirstOrDefaultAsync(x => x.Number == number);

        public async Task<IEnumerable<InvoiceDocument>> GetByCustomerAsync(Guid customerId)
            => await _context.InvoiceDocuments.Where(x => x.CustomerId == customerId).ToListAsync();

        public async Task AddAsync(InvoiceDocument invoiceDocument)
        {
            await _context.InvoiceDocuments.AddAsync(invoiceDocument);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var invoiceDocument = await GetAsync(id);
            _context.InvoiceDocuments.Remove(invoiceDocument);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveASync(string number)
        {
            var invoiceDocument = await GetAsync(number);
            _context.InvoiceDocuments.Remove(invoiceDocument);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(InvoiceDocument invoiceDocument)
        {
            _context.InvoiceDocuments.Update(invoiceDocument);
            await _context.SaveChangesAsync();
        }
    }
}
