using System;
using System.Collections.Generic;
using Invoice.Core.CustomTypes;

namespace Invoice.Core.Domain
{
    public class InvoiceDocument
    {
        
        public Guid Id { get; protected set; }
        public Guid CustomerId { get; protected set; }
        public string Number { get; protected set; }
        public string Place { get; protected set; }
        public decimal Amount { get; protected set; }
        public decimal LeftToPay { get; protected set; }
        public EnumPaymentMethod PaymentMethod { get; protected set; }
        public IEnumerable<Product> Products { get; protected set; }
        public DateTime CreatedAt {get; protected set; }
		public DateTime UpdatedAt { get; protected set; }
        public DateTime ServiceDoneAt { get; protected set; }
        public int PaymentDate { get; protected set; }
        
        protected InvoiceDocument()
        {
        }

        public InvoiceDocument(Guid customerid, string number, decimal amount, IEnumerable<Product> services,
                       DateTime serviceDoneAt, int paymentDate, decimal optLeftToPay = 0,
                       string optPlace = null, EnumPaymentMethod optPaymentMethod = EnumPaymentMethod.Unsettled)
        {
            if(string.IsNullOrWhiteSpace(number))
            {
                throw new Exception("Invoice number can not be empty."); 
            }
			if (amount < 0)
			{
				throw new Exception("Amount can not be less than 0.");
			}
			if (optLeftToPay > Amount)
			{
				throw new Exception("Left to pay can not be greather than amount.");
			}
			if (optLeftToPay < 0)
			{
				throw new Exception("Left to pay can not be less than 0.");
			}
			if (paymentDate < 0)
			{
				throw new Exception("Payment date cannot be less than 0.");
			}

            Id = Guid.NewGuid();
            CustomerId = customerid;
            Number = number;
            Place = optPlace;
            Amount = amount;
            LeftToPay = optLeftToPay;
            PaymentMethod = optPaymentMethod;
            Products = services;
            ServiceDoneAt = serviceDoneAt;
            PaymentDate = paymentDate;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetCustomerId(Guid customerId)
        {
            CustomerId = Update<Guid>(CustomerId, customerId);
        }
        
        public void SetPlace(string place)
        {
            Place = Update<string>(Place, place);
        }

        public void SetToPay(decimal amount)
        {
            if(amount < 0)
            {
                throw new Exception("Amount can not be less than 0.");
            }
            Amount = Update<decimal>(Amount, amount);
        }

        public void SetLeftToPay(decimal leftToPay)
        {
            if(leftToPay > Amount)
            {
                throw new Exception("Left to pay can not be greather than amount."); 
            }
            if (leftToPay < 0)
            {
                throw new Exception("Left to pay can not be less than 0.");
            }
            LeftToPay = Update<decimal>(LeftToPay, leftToPay);
        }

        public void SetPaymentMethod(EnumPaymentMethod paymentMethod)
        {
            PaymentMethod = Update<EnumPaymentMethod>(PaymentMethod, paymentMethod);
        }

        public void SetProducts(IEnumerable<Product> products)
        {
            Products = Update<IEnumerable<Product>>(Products, products);
        }

        public void SetServiceDoneAt(DateTime serviceDoneAt)
        {
            ServiceDoneAt = Update<DateTime>(ServiceDoneAt, serviceDoneAt);
        }

        public void SetPaymentDate (int paymentDate)
        {
            if(paymentDate < 0)
            {
                throw new Exception("Payment date cannot be less than 0.");
            }
            PaymentDate = Update<int>(PaymentDate, paymentDate);
        }

        private T Update<T>(T oldValue, T newValue)
        {
            if(oldValue.Equals(newValue))
            {
                return oldValue;
            }
            UpdatedAt = DateTime.UtcNow;
            return newValue;
        }
    }
}