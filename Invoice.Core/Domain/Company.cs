using System;
using System.Text.RegularExpressions;

namespace Invoice.Core.Domain
{
    public class Company
    {
        public string Nip {get; private set; }
        public string Name {get; private set; }
        public string Address {get; private set; }
        public string Email {get; private set; }
        public DateTime CreatedAt {get; private set; }
        public DateTime UpdatedAt {get; private set; }

        protected Company()
        {
        }

        public Company(string nip, string name, string address, string optEmail = null)
        {
            if (nip.Length != 10)
            {
                throw new Exception ("NIP length is invalid.");
            }
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new Exception("Company name can not be empty.");
			}
			if (string.IsNullOrWhiteSpace(address))
			{
				throw new Exception("Company adress can not be empty.");
			}
            Nip = nip;
            Name = name;
            Address = address;
            Email = optEmail;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetName (string name)
        {
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
            if(oldValue.Equals(newValue))
            {
                return oldValue;
            }
            UpdatedAt = DateTime.UtcNow;
            return newValue;
        }
    }
}