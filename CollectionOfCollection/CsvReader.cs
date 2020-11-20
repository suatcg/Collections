using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ReadAllCountries
{
    class CsvReader
    {
        private string _csvFilePath;
        public CsvReader(string csvFilepath) 
        {
            _csvFilePath = csvFilepath;
        }

        public Dictionary<string,List<Country>> ReadAllCountries()
        {
            var countries = new Dictionary<string, List<Country>>();

            
            using(StreamReader sr = new StreamReader(_csvFilePath))
            {
                // read header line
                sr.ReadLine();

                string csvLine;
                while((csvLine = sr.ReadLine()) != null)
                {
                    Country country = ReadCountryFromCsvLine(csvLine);
                    if(countries.ContainsKey(country.Region))
                    {
                        countries[country.Region].Add(country);
                    }
                    else
                    {
                        List<Country> countriesInRegion = new List<Country>() { country };
                        countries.Add(country.Region, countriesInRegion);
                    }
                }
            }

            return countries;
        }

        public void RemoveCommaCountries(List<Country> countries)
        {
            countries.RemoveAll(x => x.Name.Contains(','));
            
            //for (int i = countries.Count - 1; i >= 0; i--)
            //{
            //    //if (countries[i].Name.Contains(','))
            //    //    countries.RemoveAt(i);

            //}
        }


        public Country ReadCountryFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(new char[] { ',' });

            string name;
            string code;
            string region;
            string populationText;


            switch (parts.Length)
            {
                case 6:
                    name = parts[3];
                    code = parts[4];
                    region = parts[2];
                    populationText = parts[5];
                    break;
                case 7:
                    name = parts[3] + ", " + parts[4];
                    name = name.Replace("\"", null).Trim();
                    code = parts[5];
                    region = parts[2];
                    populationText = parts[6];
                    break;
                default:
                    throw new Exception($"Cant parse country from csvLine: {csvLine} ");

            }

            // TryParse leaves population equal zero if cant't parse
            int.TryParse(populationText, out int population);

            return new Country(name, code, region, population);
        }
    }
}
 