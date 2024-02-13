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
    class Vacuum : Appliance
    {
        public string Grade { get; private set; }
        public int BatteryVoltage { get; private set; }

        public Vacuum(string[] parts) : base(parts)
        {
            Grade = parts[6];
            BatteryVoltage = int.Parse(parts[7]);
        }

        public override string ToString()
        {
            string voltageDescription = BatteryVoltage == 18 ? "Low" : "High";
            return $"ItemNumber: {ItemNumber}\n" +
                   $"Brand: {Brand}\n" +
                   $"Quantity: {Quantity}\n" +
                   $"Wattage: {Wattage}\n" +
                   $"Color: {Color}\n" +
                   $"Price: {Price}\n" +
                   $"Grade: {Grade}\n" +
                   $"Battery Voltage: {voltageDescription}\n";
        }



    }
}
