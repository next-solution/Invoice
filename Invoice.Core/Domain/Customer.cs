using System;
using System.Text.RegularExpressions;

namespace Invoice.Core.Domain
{
    public class Customer
    {
        private static readonly Regex ZipCodeRegex = new Regex(@"^\d{2}-\d{3}$");
        public Guid Id { get; protected set; }
        public int Nip { get; protected set; }
        public string Name { get; protected set; }
        public string Address { get; protected set; }
        public string ZipCode { get; protected set; }
        public string City { get; protected set; }
        public string Email {get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Customer()
        {
        }
        public Customer (int nip, string name, string address, string zipCode, string city)
        {
            if (!ZipCodeRegex.IsMatch(zipCode))
            {
                throw new Exception ("Zip code is invalid.");
            }
            Id = Guid.NewGuid();
            Nip = nip;
            Name = name;
            Address = address;
            SetZipCode(zipCode);
            City = city;
            CreatedAt = DateTime.UtcNow;
            new InvoiceLayout(Guid.NewGuid());
        }
        public void SetName (string name)
        {
            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }
        public void SetAddress (string address)
        {
            Address = address;
            UpdatedAt = DateTime.UtcNow;
        }
        public void SetZipCode (string zipCode)
        {
            if (!ZipCodeRegex.IsMatch(zipCode))
            {
                throw new Exception ("Zip code is invalid.");
            }
            ZipCode = zipCode;
            UpdatedAt = DateTime.UtcNow;
        }
        public void SetCity(string city)
        {
            City = city;
            UpdatedAt = DateTime.UtcNow;
        }
        public void SetEmail(string email)
        {
            Email = email;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}