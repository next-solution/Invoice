using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice.Infrastructure.Commands;
using NLog;
using Invoice.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Api.Controllers
{
    public class InvoiceDocumentController : ApiControllerBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IInvoiceDocumentService _invoiceDocumentService;

        public InvoiceDocumentController(IInvoiceDocumentService invoiceDocumentService,
            ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _invoiceDocumentService = invoiceDocumentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Logger.Info($"Fetching all invoices...");
            var invoiceDocuments = await _invoiceDocumentService.GetAllAsync();
            if(invoiceDocuments == null)
            {
                return NotFound();
            }
            return Json(invoiceDocuments);
        }

        [HttpGet]
        public async Task<IActionResult> Get (string number)
        {
            Logger.Info($"Fetching invoice with number: {number}");
            var invoiceDocument = await _invoiceDocumentService.GetAsync(number);
            if(invoiceDocument == null)
            {
                return NotFound();
            }
            return Json(invoiceDocument);
        }

    }
}
