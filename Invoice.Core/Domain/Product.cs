using System;
using Invoice.Core.CustomTypes;

namespace Invoice.Core.Domain
{
    public class Product
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public decimal Tax { get; protected set; }
        public EnumUnitOfMeasure UnitOfMeasure { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set;  }

        protected Product()
        {
        }

        public Product(string name, decimal price, decimal optTax = 0.23M, 
                       EnumUnitOfMeasure optUnitOfMeasure = EnumUnitOfMeasure.Szt)
        {
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new Exception("Product's name can not be empty.");
			}
			if (price < 0)
			{
				throw new Exception("Price can not be less than 0.");
			}
			if (optTax < 0)
			{
				throw new Exception("Tax can not be less than 0");
			}
            Id = new Guid();
            Name = name;
            Price = price;
            Tax = optTax;
            UnitOfMeasure = optUnitOfMeasure;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetName (string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Product's name can not be empty.");
            }
            Name = Update<string>(Name, name);
        }

        public void SetPrice (decimal price)
        {
            if (price < 0)
            {
                throw new Exception("Price can not be less than 0."); 
            }
            Price = Update<decimal>(Price, price);
        }

        public void SetTax (decimal tax)
        {
            if (tax < 0)
            {
                throw new Exception("Tax can not be less than 0"); 
            }
            Tax = Update<decimal>(Tax, tax);
        }

        public void SetUnitOfMeasure (EnumUnitOfMeasure unitOfMeasure)
        {
            UnitOfMeasure = Update<EnumUnitOfMeasure>(UnitOfMeasure, unitOfMeasure);
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