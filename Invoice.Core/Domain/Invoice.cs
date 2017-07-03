using System;
using System.Collections.Generic;

namespace Invoice.Core.Domain
{
    public class Invoice
    {
        public Guid Id { get; protected set; }
        public Guid CustomerId { get; protected set; }
        public string Number { get; protected set; }
        public string Place { get; protected set; }
        public decimal PaidUp { get; protected set; }
        public IEnumerable<Service> Services { get; protected set; }
        public enum PaymentMethod {transfer, cash}
        //? public _PaymentMethod PaymentMethod {get; protected set;}
        public DateTime CreatedAt {get; protected set; }
        public DateTime ServiceDoneAt { get; protected set; }
        public DateTime PaymentDate {get; protected set; }
        
        protected Invoice()
        {
        }
        public Invoice(Guid customerid, string number, string place)
        {
            Id = Guid.NewGuid();
            CustomerId = customerid;
            Number = number;
            Place = place;
            var layout = new InvoiceLayout(Id);
        }
        

    }
}