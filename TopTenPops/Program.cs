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

            countries.Insert(firstLIndex + liliputIndexOne, liliput);


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

            Console.Write("Enter no. of countries to display> ");
            bool inputIsInt = int.TryParse(Console.ReadLine(), out int userInput);

            if(!inputIsInt || userInput <= 0)
            {
                Console.WriteLine("You must type in a +ve interger. Exiting");
                return;
            }


            int maxToDisplay = userInput;

            for (int i = countries.Count - 1; i >= 0 ; i--)
            {
                int displayIndex = countries.Count - 1 - i;
                //if (i > 0 && (i % maxToDisplay == 0))
                if(displayIndex > 0 && (displayIndex % maxToDisplay == 0))
                {
                    Console.WriteLine("Hit return to continue, anything else to quit");
                    if (Console.ReadLine() != "")
                        break;
                }
                Country country = countries[i];
                Console.WriteLine($"{displayIndex + 1} : {PopulationFormat.FormatPopulation(country.Population).PadLeft(15) }: {country.Name}");
            }

            /*
             * get specific number of countries
            int maxToDisplay = Math.Min(userInput, countries.Count);

            for (int i = 0; i < maxToDisplay; i++)
            {
                Country country = countries[i];
                Console.WriteLine($"{PopulationFormat.FormatPopulation(country.Population).PadLeft(15) }: {country.Name}");
            }
            */


            //foreach (var country in countries)
            //{
            //    Console.WriteLine($"{PopulationFormat.FormatPopulation(country.Population).PadLeft(15) }: {country.Name}");
            //}

            //Console.WriteLine($"{countries.Count} countries");
        }
    }
}
