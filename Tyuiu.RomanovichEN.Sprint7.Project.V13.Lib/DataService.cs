using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tyuiu.RomanovichEN.Sprint7.Project.V13.Lib
{
    public class Country
    {
        public string Name { get; set; }
        public string Capital { get; set; }
        public double Area { get; set; }
        public bool IsDeveloped { get; set; }
        public long Population { get; set; }
        public string PredominantNationality { get; set; }
        public string Notes { get; set; }
    }

    public class DataService
    {
        private const string FilePath = "countries.csv";

        public List<Country> Countries { get; private set; }

        public DataService()
        {
            Countries = new List<Country>();
        }
        public void LoadData()
        {
            var lines = File.ReadAllLines(FilePath);

            for (int i = 1; i < lines.Length; i++)
            {
                var fields = lines[i].Split(',');

                var country = new Country
                {
                    Name = fields[0],
                    Capital = fields[1],
                    Area = double.Parse(fields[2].Replace(',', '.'),
                        System.Globalization.CultureInfo.InvariantCulture),
                    IsDeveloped = bool.Parse(fields[3]),
                    Population = long.Parse(fields[4]),
                    PredominantNationality = fields[5],
                    Notes = fields[6]
                };
                Countries.Add(country);
            }
        }
        public void LoadDataFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);

            for (int i = 1; i < lines.Length; i++)
            {
                var fields = lines[i].Split(',');

                var country = new Country
                {
                    Name = fields[0],
                    Capital = fields[1],
                    Area = double.Parse(fields[2].Replace(',', '.'),
                        System.Globalization.CultureInfo.InvariantCulture),
                    IsDeveloped = bool.Parse(fields[3]),
                    Population = long.Parse(fields[4]),
                    PredominantNationality = fields[5],
                    Notes = fields[6]
                };
                Countries.Add(country);
            }
        }

        public void SaveData()
        {
            var lines = new List<string>();

            lines.Add("Name,Capital,Area,IsDeveloped,Population,PredominantNationality,Notes");

            foreach (var country in Countries)
            {
                var line = string.Join(",",
                    country.Name,
                    country.Capital,
                    country.Area.ToString(System.Globalization.CultureInfo.InvariantCulture),
                    country.IsDeveloped.ToString(),
                    country.Population.ToString(),
                    country.PredominantNationality,
                    country.Notes
                );
                lines.Add(line);
            }

            File.WriteAllLines(FilePath, lines);
        }

        public void AddCountry(Country country)
        {
            Countries.Add(country);
        }

        public Country GetCountryByName(string name)
        {
            return Countries.FirstOrDefault(c =>
                c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void RemoveCountry(string name)
        {
            var country = GetCountryByName(name);
            if (country != null)
            {
                Countries.Remove(country);
            }
        }
    }
}