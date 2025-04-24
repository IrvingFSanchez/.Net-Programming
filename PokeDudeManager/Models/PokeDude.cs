using System;
using Microsoft.Data.SqlClient;
namespace PokeDudeManager.Models
{
    public class PokeDude
    {
        public int PokeDudeID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime DiscoveryDate { get; set; }

        public PokeDude()
        {
            Name = string.Empty;
            Type = string.Empty;
            Gender = string.Empty;
            Location = string.Empty;
        }

        public PokeDude(string name, string type, string gender, string location, DateTime date)
        {
            Name = name;
            Type = type;
            Gender = gender;
            Location = location;
            DiscoveryDate = date;
        }

        public override string ToString()
        {
            return $"{PokeDudeID}\n{Name}\n{Type}\n{Gender}\n{Location}\n{DiscoveryDate:yyyy-MM-dd}";
        }
    }
}