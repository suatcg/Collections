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
                foreach (Country country in countries[chosenRegion].Take(20))
                {
                    Console.WriteLine($"{PopulationFormat.FormatPopulation(country.Population).PadLeft(15) }: {country.Name}");
                }
            }
            else
                Console.WriteLine("That is not a valid region");



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

            /*
             * 
            Console.Write("Enter no. of countries to display> ");
            bool inputIsInt = int.TryParse(Console.ReadLine(), out int userInput);

            if(!inputIsInt || userInput <= 0)
            {
                Console.WriteLine("You must type in a +ve interger. Exiting");
                return;
            }


            
            int maxToDisplay = userInput;

            //for (int i = countries.Count - 1; i >= 0 ; i--)
            for(int i = 0; i < countries.Count; i++)
            {

                //int displayIndex = countries.Count - 1 - i;
                //if(displayIndex > 0 && (displayIndex % maxToDisplay == 0))
                if (i > 0 && (i % maxToDisplay == 0))
                {
                    Console.WriteLine("Hit return to continue, anything else to quit");
                    if (Console.ReadLine() != "")
                        break;
                }
                Country country = countries[i];
                Console.WriteLine($"{i + 1} : {PopulationFormat.FormatPopulation(country.Population).PadLeft(15) }: {country.Name}");
            }

            */

            /*
             * get specific number of countries
            int maxToDisplay = Math.Min(userInput, countries.Count);

            for (int i = 0; i < maxToDisplay; i++)
            {
                Country country = countries[i];
                Console.WriteLine($"{PopulationFormat.FormatPopulation(country.Population).PadLeft(15) }: {country.Name}");
            }
            */

            // LINQ method sytanx which saying it's normal c# syntax
            var filteredCountries = countries.OrderByDescending(x => x.Population).Where(x => !x.Name.Contains(','));//.Take(20);

            // this syntax is same above which is LINQ query syntax that tries to mimic SQL
            // Complex queries can be more readable (advantage)
            // Doesn't support all LINQ features (disadvantage), It only supports a subset of what LINQ can do because we removed
            // The Take(20) call from the filtered countries query "Take" doesn't support in LINQ query syntax
            // New syntax to learn (disadvantage)  
            var filteredCountries2 = from country in countries
                                    where !country.Name.Contains(',')
                                    select country;

            foreach (var country in filteredCountries)
            {
                Console.WriteLine($"{PopulationFormat.FormatPopulation(country.Population).PadLeft(15) }: {country.Name}");
            }

            Console.WriteLine($"{countries.Count} countries");
        }
    }
}
