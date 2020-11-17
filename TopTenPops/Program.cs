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

            List<Country> countries = reader.ReadAllCountries();



            var liliput = new Country("Liliput", "LIL", "Somewhere", 2_000_000);
            List<Country> liliputStartWithL = countries.FindAll(x => x.Name.StartsWith('L'));

            var valueChar = GetValueLili(liliputStartWithL);
            
            var liliputIndexOne = liliputStartWithL.FindIndex(x => x.Name.ElementAt(1).Equals((char)(valueChar)));

            var firstLIndex = countries.FindIndex(x => x.Name.StartsWith('L'));

            countries.Insert(firstLIndex+ liliputIndexOne, liliput);


            static byte GetValueLili(List<Country> list)
            {
                var newlist = new List<byte>();
                foreach (var lili in list)
                {
                    // 97 = 'a' ASCII code ,105 = 'i' ASCII code
                    if ((byte)lili.Name[1] >= 97 & (byte)lili.Name[1] <= 105)
                    {
                        newlist.Add((byte)lili.Name[1]);
                    }
                }

                return (byte)newlist.Max();
                
            }
            
            
            


            foreach (var country in countries)
            {
                Console.WriteLine($"{PopulationFormat.FormatPopulation(country.Population).PadLeft(15) }: {country.Name}");
            }

            Console.WriteLine($"{countries.Count} countries");
        }
    }
}
