using SampleHierarchies.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data
{
    public class Settings : ISettings
    {
        public string? Version { get; set; }
        public string? MainScreenColor { get; set; } 
        public string? AnimalsScreenColor { get; set; }
        public string? MammalSpeciesColor { get; set; }
        public string? DogsScreenColor { get; set; }
        public string? OrungutanScreenColor { get; set; }
        public string? ElephantScreenColor { get; set; }


        public Settings(string? version, string? mainScreenColor, string? animalsScreenColor, string? mammalSpecies, string? dogsScreenColor, string? orungutanScreenColor, string? elephantScreenColor)
        {
            Version = version;
            MainScreenColor = mainScreenColor;
            AnimalsScreenColor = animalsScreenColor;
            MammalSpeciesColor = mammalSpecies;
            DogsScreenColor = dogsScreenColor;
            OrungutanScreenColor = orungutanScreenColor;
            ElephantScreenColor = elephantScreenColor;
        }

        public Settings(string? mainScreenColor, string? animalsScreenColor, string? mammalSpecies, string? dogsScreenColor, string? orungutanScreenColor, string? elephantScreenColor)
        {
            MainScreenColor = mainScreenColor;
            AnimalsScreenColor = animalsScreenColor;
            MammalSpeciesColor = mammalSpecies;
            DogsScreenColor = dogsScreenColor;
            OrungutanScreenColor = orungutanScreenColor;
            ElephantScreenColor = elephantScreenColor;
        }

        public Settings()
        {
        }
    }
}
