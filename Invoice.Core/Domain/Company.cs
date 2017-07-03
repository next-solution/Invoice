using System;
using System.Text.RegularExpressions;

namespace Invoice.Core.Domain
{
    public class Company
    {
        private static readonly Regex ZipCodeRegex = new Regex(@"^\d{2}-\d{3}$");
        static public long Nip {get; private set; }
        static public string Name {get; private set; }
        static public string Address {get; private set; }
        static public string ZipCode {get; private set; }
        static public string City {get; private set; }
        static public string Email {get; private set; }
        static public DateTime CreatedAt {get; private set; }
        static public DateTime UpdatedAt {get; private set; }

        public Company(long nip,string name, string address, string zipCode, string city, string email)
        {
            if (nip.ToString().Length != 10)
            {
                throw new Exception ("NIP length is invalid.");
            }
            Nip = nip;
            SetName(name);
            SetAddress(address);
            SetZipCode(zipCode);
            SetCity(city);
            SetEmail(email);
        }
        static public void SetName (string name)
        {
            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }
        static public void SetAddress (string address)
        {
            Address = address;
            UpdatedAt = DateTime.UtcNow;
        }
        static public void SetZipCode (string zipCode)
        {
            if (!ZipCodeRegex.IsMatch(zipCode))
            {
                throw new Exception ("Zip code is invalid.");
            }
            ZipCode = zipCode;
            UpdatedAt = DateTime.UtcNow;
        }
        static public void SetCity(string city)
        {
            City = city;
            UpdatedAt = DateTime.UtcNow;
        }
        static public void SetEmail(string email)
        {
            Email = email;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}