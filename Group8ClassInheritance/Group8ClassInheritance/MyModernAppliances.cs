using Group8ClassInheritance.Entities.Abstract;
using Group8ClassInheritance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group8ClassInheritance
{
    class MyModernAppliance
    {
        private ModernAppliance modernAppliance;

        public MyModernAppliance()
        {
            modernAppliance = new ModernAppliance();
        }

        public void Run()
        {
            int option;
            do
            {
                DisplayMainMenu();
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    InvalidOptionMessage();
                    continue;
                }

                switch (option)
                {
                    case 1:
                        CheckoutAppliance();
                        break;
                    case 2:
                        FindAppliancesByBrand();
                        break;
                    case 3:
                        DisplayAppliancesByType();
                        break;
                    case 4:
                        ProduceRandomApplianceList();
                        break;
                    case 5:
                        ExitProgram();
                        break;
                    default:
                        InvalidOptionMessage();
                        break;
                }
            } while (option != 5);
        }

        private void DisplayMainMenu()
        {
            Console.WriteLine("Welcome to Modern Appliances!");
            Console.WriteLine("How May We Assist You?");
            Console.WriteLine("1 – Check out appliance");
            Console.WriteLine("2 – Find appliances by brand");
            Console.WriteLine("3 – Display appliances by type");
            Console.WriteLine("4 – Produce random appliance list");
            Console.WriteLine("5 – Save & exit");
            Console.WriteLine("Enter option:");
        }

        private void InvalidOptionMessage()
        {
            Console.WriteLine("Invalid option. Please enter a number between 1 and 5.");
        }

        private void CheckoutAppliance()
        {
            Console.WriteLine("Enter the item number of an appliance:");
            string itemNumber = Console.ReadLine();
            modernAppliance.Checkout(itemNumber);
        }

        private void FindAppliancesByBrand()
        {
            Console.WriteLine("Enter brand to search for:");
            string brand = Console.ReadLine();
            Console.WriteLine($"Searching for brand: {brand}");
            modernAppliance.FindByBrand(brand);
        }

        private void DisplayAppliancesByType()
        {
            Console.WriteLine("Appliance Types");
            Console.WriteLine("1 – Refrigerators");
            Console.WriteLine("2 – Vacuums");
            Console.WriteLine("3 – Microwaves");
            Console.WriteLine("4 – Dishwashers");
            Console.WriteLine("Enter type of appliance:");
            int type;
            if (!int.TryParse(Console.ReadLine(), out type) || type < 1 || type > 4)
            {
                Console.WriteLine("Invalid appliance type.");
                return;
            }

            switch (type)
            {
                case 1:
                    Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors), or 4 (four doors):");
                    if (!int.TryParse(Console.ReadLine(), out int numberOfDoors) || (numberOfDoors != 2 && numberOfDoors != 3 && numberOfDoors != 4))
                    {
                        modernAppliance.DisplayRefrigerators(numberOfDoors);
                    }
                    else
                    {
                        modernAppliance.DisplayRefrigerators(numberOfDoors);
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high)");
                    int batteryVoltage;
                    if (!int.TryParse(Console.ReadLine(), out batteryVoltage) || (batteryVoltage != 18 && batteryVoltage != 24))
                    {
                        modernAppliance.DisplayVacuums(batteryVoltage);
                    }
                    else
                    {
                        modernAppliance.DisplayVacuums(batteryVoltage);
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter room type: K (Kitchen) or W (Work Site):");
                    char roomType = char.ToUpper(Console.ReadLine().FirstOrDefault());
                    if (roomType == 'K' || roomType == 'W')
                    {
                        modernAppliance.DisplayMicrowaves(roomType);
                        
                    }
                    else
                    {
                        Console.WriteLine("No preferred room type selected properly Showing all products");
                        modernAppliance.DisplayMicrowaves();
                    }
                    break;
                case 4:
                    Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu (Quiet) or M (Moderate):");
                    string soundRating = Console.ReadLine();
                    modernAppliance.DisplayDishwashers(soundRating);
                    break;
            }
        }

        private void ProduceRandomApplianceList()
        {
            Console.WriteLine("Enter number of appliances:");
            int count;
            if (!int.TryParse(Console.ReadLine(), out count) || count < 1)
            {
                Console.WriteLine("Invalid number.");
                return;
            }

            modernAppliance.DisplayRandomList(count);
        }

        private void ExitProgram()
        {
            modernAppliance.PersistAppliancesToFile("appliances.txt");
            Console.WriteLine("Appliances saved to file. Exiting program.");
        }
    }
}
