using ReadAllCountries;
using System;
using System.Collections.Generic;

namespace CollectionsDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var norway = new Country("Norway", "NOR", "Europe", 5_282_223);
            var finland = new Country("Findland", "FIN", "Europe", 5_511_303);

            var countries = new Dictionary<string, Country>
            {
                { norway.Code, norway },
                { finland.Code, finland }
            };

            // Other way
            //countries.Add(norway.Code, norway);
            //countries.Add(finland.Code, finland);

            bool exists = countries.TryGetValue("MUS", out Country country);

            if(exists)
                Console.WriteLine(country.Name);
            else
                Console.WriteLine("There is no country with the code MUS");

            foreach (var item in countries.Values)
            {
                Console.WriteLine(item.Name);
            }
            */

            string filePath = @"C:\Users\Suat-\PopByLargestFinal.csv";

            var reader = new CsvReader(filePath);
            
            Dictionary<string, Country> countries = reader.ReadAllCountries();

            Console.WriteLine("Which country code do you want to look up?");
            
            string userInput = Console.ReadLine();

            bool gotCountry = countries.TryGetValue(userInput, out Country country);

            if(!gotCountry)
                Console.WriteLine($"Sorry, ther is no country with code, {userInput}");
            else
                Console.WriteLine($"{country.Name} has population {PopulationFormat.FormatPopulation(country.Population)}");

        }
    }
}
