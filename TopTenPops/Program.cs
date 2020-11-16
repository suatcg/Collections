using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadAllCountries
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Suat-\PopByLargestFinal.csv";

            var reader = new CsvReader(filePath);

            List<Country> countries = reader.ReadAllCountries();

            //countries.OrderByDescending(x => x.Population);
            foreach (var country in countries)
            {
                Console.WriteLine($"{PopulationFormat.FormatPopulation(country.Population).PadLeft(15) }: {country.Name}");
            }
        }
    }
}
