using Invoice.Core.CustomTypes;
using Invoice.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.Infrastructure.DTO
{
    public class InvoiceDocumentDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Number { get; set; }
        public string Place { get; set; }
        public decimal Amount { get; set; }
        public decimal LeftToPay { get; set; }
        public EnumPaymentMethod PaymentMethod { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public DateTime ServiceDoneAt { get; set; }
        public int PaymentDate { get; set; }
    }
}
