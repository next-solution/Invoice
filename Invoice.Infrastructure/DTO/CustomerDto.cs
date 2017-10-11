
using System;

namespace Invoice.Infrastructure.DTO
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string Nip { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email {get; set; }
    }
}