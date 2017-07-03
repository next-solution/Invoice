using System;

namespace Invoice.Infrastructure.DTO
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        //TIN - tax identification number
        public int Tin { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Email {get; set; }
    }
}