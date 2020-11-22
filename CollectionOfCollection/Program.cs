using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace ReadAllCountries
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Suat-\PopByLargestFinal.csv";

            var reader = new CsvReader(filePath);

            Dictionary<string, List<Country>> countries = reader.ReadAllCountries();
            foreach(string region in countries.Keys)
                Console.WriteLine(region);

            Console.Write("Which of the above regions do you want ?");
            string chosenRegion = Console.ReadLine();

            if(countries.ContainsKey(chosenRegion))
            {
                foreach (Country country in countries[chosenRegion].Take(10))
                {
                    Console.WriteLine($"{PopulationFormat.FormatPopulation(country.Population).PadLeft(15) }: {country.Name}");
                }
            }
            else
                Console.WriteLine("That is not a valid region");

        }
    }
}
