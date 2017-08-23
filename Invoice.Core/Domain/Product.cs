using System;
using Invoice.Core.CustomTypes;

namespace Invoice.Core.Domain
{
    public class ProductOrService
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public decimal Tax { get; protected set; }
        public EnumUnitOfMeasure UnitOfMeasure { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set;  }

        protected ProductOrService()
        {
        }

        public ProductOrService(string name, decimal price, decimal tax, EnumUnitOfMeasure unitOfMeasure)
        {
            Id = new Guid();
            Name = name;
            Price = price;
            Tax = tax;
            UnitOfMeasure = unitOfMeasure;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetName (string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Product's name can not be empty.");
            }
            if (name == Name)
            {
                return;
            }
            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPrice (decimal price)
        {
            if (price < 0)
            {
                throw new Exception("Price can not be less than 0."); 
            }
            if (price == Price)
            {
                return;
            }
            Price = price;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetTax (decimal tax)
        {
            if (tax < 0)
            {
                throw new Exception("Tax can not be less than 0"); 
            }
            if (tax == Tax)
            {
                return;
            }
            Tax = tax;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetUnitOfMeasure (EnumUnitOfMeasure unitOfMeasure)
        {
            if (unitOfMeasure == UnitOfMeasure)
            {
                return;
            }
            UnitOfMeasure = unitOfMeasure;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}