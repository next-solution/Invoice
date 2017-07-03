using System;

namespace Invoice.Core.Domain
{
    public class Service
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public decimal tax { get; protected set; } 
    }
}