using System;
using System.Text.RegularExpressions;

namespace Invoice.Core.Domain
{
    public class Customer
    {
        public Guid Id { get; protected set; }
        public string Nip { get; protected set; }
        public string Name { get; protected set; }
        public string Address { get; protected set; }
        public string Email {get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Customer()
        {
        }

        public Customer(string nip, string name, string address, string optEmail = null)
        {
            if (nip.ToString().Length != 10)
			{
				throw new Exception("Customer nip is invalid.");
			}
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new Exception("Customer name can not be empty.");
			}
            if (string.IsNullOrWhiteSpace(address))
			{
				throw new Exception("Customer adress can not be empty.");
			}
            Id = Guid.NewGuid();
            Nip = nip;
            Name = name;
            Address = address;
            Email = optEmail;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetName (string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Customer name can not be empty.");
            }
            Name = Update<string>(Name, name);
        }

        public void SetAddress (string address)
        {
            Address = Update<string>(Address, address);
        }

        public void SetEmail(string email)
        {
            Email = Update<string>(Email, email);
        }
		
        private T Update<T>(T newValue, T oldValue)
		{
			if (oldValue.Equals(newValue))
			{
				return oldValue;
			}
			UpdatedAt = DateTime.UtcNow;
			return newValue;
		}
    }
}