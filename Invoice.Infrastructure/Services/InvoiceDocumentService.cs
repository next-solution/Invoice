using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Invoice.Core.Domain;
using Invoice.Infrastructure.DTO;
using Invoice.Core.Repositories;
using AutoMapper;

namespace Invoice.Infrastructure.Services
{
    public class InvoiceDocumentService : IInvoiceDocumentService
    {
        private readonly IInvoiceDocumentRepository _invoiceDocumentRepository;
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter;

        public InvoiceDocumentService(IInvoiceDocumentRepository invoiceDocumentRepository, IMapper mapper, IEncrypter encrypter)
        {
            _invoiceDocumentRepository = invoiceDocumentRepository;
            _mapper = mapper;
            _encrypter = encrypter;
        }

        public async Task<IEnumerable<InvoiceDocumentDto>> GetAllAsync()
        {
            var invoiceDocuments = await _invoiceDocumentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<InvoiceDocument>, IEnumerable<InvoiceDocumentDto>>
                (invoiceDocuments);
        }

        public async Task<InvoiceDocumentDto> GetAsync(Guid id)
        {
            var invoiceDocument = await _invoiceDocumentRepository.GetAsync(id);
            return _mapper.Map<InvoiceDocument, InvoiceDocumentDto>(invoiceDocument);
        }

        public async Task<InvoiceDocumentDto> GetAsync(string number)
        {
            var invoiceDocument = await _invoiceDocumentRepository.GetAsync(number);
            return _mapper.Map<InvoiceDocument, InvoiceDocumentDto>(invoiceDocument);
        }

        public Task CreateAsync(Guid companyId, Guid customerId, IEnumerable<Product> products)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
