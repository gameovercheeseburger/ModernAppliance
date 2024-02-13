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
    class Microwave : Appliance
    {
        public decimal Capacity { get; private set; }
        public char RoomType { get; private set; }

        public Microwave(string[] parts) : base(parts)
        {
            Capacity = decimal.Parse(parts[6]);
            RoomType = char.Parse(parts[7]);
        }

        public override string ToString()
        {
            return $"ItemNumber: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}\nCapacity: {Capacity} cu ft\nRoom Type: {(RoomType == 'K' ? "Kitchen" : "Work Site")}\n";
        }

    }

}
