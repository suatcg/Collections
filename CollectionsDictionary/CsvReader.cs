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

        public Dictionary<string, Country> ReadAllCountries()
        {
            var countries = new Dictionary<string, Country>();

            using(StreamReader sr = new StreamReader(_csvFilePath))
            {
                // read header line
                sr.ReadLine();

                string csvLine;
                while((csvLine = sr.ReadLine()) != null)
                {
                    Country country = ReadCountryFromCsvLine(csvLine);
                    countries.Add(country.Code, country);
                }
            }

            return countries;
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
 