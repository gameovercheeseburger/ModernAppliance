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
    class Dishwasher : Appliance
    {
        public string SoundRating { get; private set; }
        public string Feature { get; private set; }

        public Dishwasher(string[] parts) : base(parts)
        {
            Feature = parts[6];
            SoundRating = parts[7];
        }
        private string GetSoundRatingDescription(string abbreviation)
        {
            switch (abbreviation)
            {
                case "Qt":
                    return "Quietest";
                case "Qr":
                    return "Quieter";
                case "Qu":
                    return "Quiet";
                case "M":
                    return "Moderate";
                default:
                    return "Unknown";
            }
        }
        public override string ToString()
        {
            return $"ItemNumber: {ItemNumber}\n" +
                   $"Brand: {Brand}\n" +
                   $"Quantity: {Quantity}\n" +
                   $"Wattage: {Wattage}\n" +
                   $"Color: {Color}\n" +
                   $"Price: {Price}\n" +
                   $"Feature: {Feature}\n" +
                   $"Sound Rating: {GetSoundRatingDescription(SoundRating)}\n";
        }


    }
}
