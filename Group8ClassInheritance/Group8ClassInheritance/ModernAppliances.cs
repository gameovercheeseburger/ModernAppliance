using Group8ClassInheritance.Entities.Abstract;
using Group8ClassInheritance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Group8ClassInheritance
{
    class ModernAppliance
    {
        private List<Appliance> appliances;

        public ModernAppliance()
        {
            appliances = new List<Appliance>();
            ParseAppliancesFromFile("appliances.txt");
        }

        private void ParseAppliancesFromFile(string filename)
        {

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length < 2)
                        continue;

                    if (parts[0][0] == '1')
                    {
                        appliances.Add(new Refrigerator(parts));
                    }
                    else if (parts[0][0] == '2')
                    {
                        appliances.Add(new Vacuum(parts));
                    }
                    else if (parts[0][0] == '3')
                    {
                        appliances.Add(new Microwave(parts));
                    }
                    else if (parts[0][0] == '4')
                    {
                        appliances.Add(new Dishwasher(parts));
                    }
                }
            }
        }

        public void Checkout(string itemNumber)
        {
            
            Appliance appliance = appliances.Find(a => a.ItemNumber == itemNumber);
            if (appliance != null)
            {
                if (appliance.Quantity > 0)
                {
                    Console.WriteLine($"Appliance \"{itemNumber}\" has been checked out.");
                    appliance.Quantity--;
                }
                else
                {
                    Console.WriteLine("The appliance is not available to be checked out.");
                }
            }
            else
            {
                Console.WriteLine("No appliances found with that item number.");
            }
        }

        public void FindByBrand(string brand)
        {
            List<Appliance> matchingAppliances = appliances
                .Where(a => a.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (matchingAppliances.Count == 0)
            {
                Console.WriteLine($"No appliances found with the brand '{brand}'.");
                return;
            }

            Console.WriteLine("Matching Appliances:");

            foreach (Appliance appliance in matchingAppliances)
            {
                Console.WriteLine(appliance);
            }
        }

        public void DisplayRefrigerators()
        {
            foreach (Appliance appliance in appliances)
            {
                if (appliance is Refrigerator)
                {
                    Console.WriteLine(appliance);
                }
            }
        }

        public void DisplayRefrigerators(int numberOfDoors)
        {
            foreach (Appliance appliance in appliances)
            {
                if (appliance is Refrigerator && ((Refrigerator)appliance).NumberOfDoors == numberOfDoors)
                {
                    Console.WriteLine(appliance);
                }
            }
        }

        public void DisplayVacuums()
        {
            foreach (Appliance appliance in appliances)
            {
                if (appliance is Vacuum)
                {
                    Console.WriteLine(appliance);
                }
            }
        }
        public void DisplayVacuums(int batteryVoltage)
        {
            string voltageDescription = batteryVoltage == 18 ? "LOW" : "HIGH";
            List<Appliance> matchingVacuums = appliances
                .Where(a => a is Vacuum && ((Vacuum)a).BatteryVoltage == batteryVoltage)
                .ToList();

            if (matchingVacuums.Count == 0)
            {
                Console.WriteLine("No vacuums found with that battery voltage.");
                return;
            }

            Console.WriteLine($"Matching Vacuums with {voltageDescription} Battery Voltage:");
            foreach (Appliance appliance in matchingVacuums)
            {
                Console.WriteLine(appliance);
            }
        }


        public void DisplayMicrowaves()
        {
            foreach (Appliance appliance in appliances)
            {
                if (appliance is Microwave)
                {
                    Console.WriteLine(appliance);
                }
            }
        }
        public void DisplayMicrowaves(char roomType)
        {
            foreach (Appliance appliance in appliances)
            {
                if (appliance is Microwave && ((Microwave)appliance).RoomType == roomType)
                {
                    Console.WriteLine(appliance);
                }
            }
        }

        public void DisplayDishwashers()
        {
            foreach (Appliance appliance in appliances)
            {
                if (appliance is Dishwasher)
                {
                    Console.WriteLine(appliance);
                }
            }
        }
        public void DisplayDishwashers(string soundRating)
        {
            string soundRatingUpper = soundRating.ToUpper();
            List<Dishwasher> matchingDishwashers = appliances
                .Where(a => a is Dishwasher && ((Dishwasher)a).SoundRating.ToUpper() == soundRatingUpper)
                .Select(a => (Dishwasher)a)
                .ToList();

            if (matchingDishwashers.Count == 0)
            {
                Console.WriteLine("No dishwashers found with the specified sound rating.");
                return;
            }

            Console.WriteLine("Matching dishwashers:");
            foreach (Dishwasher dishwasher in matchingDishwashers)
            {
                Console.WriteLine(dishwasher);
            }
        }

        public void DisplayRandomList(int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                int index = random.Next(appliances.Count);
                Console.WriteLine(appliances[index]);
            }
        }

        public void PersistAppliancesToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Appliance appliance in appliances)
                {
                    writer.WriteLine(appliance.ToFileString());
                }
            }
        }
        
    }
}
