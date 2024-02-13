using Group8ClassInheritance.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group8ClassInheritance.Entities
{
    class Refrigerator : Appliance
    {
        public int NumberOfDoors { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        public Refrigerator(string[] parts) : base(parts)
        {
            NumberOfDoors = int.Parse(parts[6]);
            Height = int.Parse(parts[7]);
            Width = int.Parse(parts[8]);
        }

        public override string ToString()
        {
            return $"ItemNumber: {ItemNumber}\n" +
                   $"Brand: {Brand}\n" +
                   $"Quantity: {Quantity}\n" +
                   $"Wattage: {Wattage}\n" +
                   $"Color: {Color}\n" +
                   $"Price: {Price}\n" +
                   $"Number of Doors: {NumberOfDoors}\n" +
                   $"Height: {Height}\n" +
                   $"Width: {Width}\n";
        }
    }
}
