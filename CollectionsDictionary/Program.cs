using ReadAllCountries;
using System;
using System.Collections.Generic;

namespace CollectionsDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
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

            foreach (var country in countries.Values)
            {
                Console.WriteLine(country.Name);
            }
        }
    }
}
