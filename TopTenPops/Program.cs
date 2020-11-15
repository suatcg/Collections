using System;

namespace TopTenPops
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Suat-\PopByLargestFinal.csv";

            var reader = new CsvReader(filePath);

            Country[] countries = reader.ReadFirstNCountries(10);

            foreach (var country in countries)
            {
                Console.WriteLine($"{PopulationFormat.FormatPopulation(country.Population).PadLeft(15) }: {country.Name}");
            }
        }
    }
}
