using System;

namespace Group8ClassInheritance.Entities.Abstract
{
    abstract class Appliance
    {
        public string ItemNumber { get; protected set; }
        public string Brand { get; protected set; }
        public int Quantity { get; set; }
        public int Wattage { get; protected set; }
        public string Color { get; protected set; }
        public decimal Price { get; protected set; }

        public Appliance(string[] parts)
        {
            ItemNumber = parts[0];
            Brand = parts[1];
            Quantity = int.Parse(parts[2]);
            Wattage = int.Parse(parts[3]);
            Color = parts[4];
            Price = decimal.Parse(parts[5]);
        }

        public abstract override string ToString();

        public virtual string ToFileString()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price}";
        }
    }
}
