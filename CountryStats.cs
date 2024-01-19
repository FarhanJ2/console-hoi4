using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class CountryStats
{
    public List<Country> Countries { get; set; }

    public CountryStats()
    {
        Countries = new List<Country>();
    }

    public static CountryStats LoadFromJson(string filePath)
    {
        try
        {
            string jsonContent = System.IO.File.ReadAllText(filePath);
            CountryStats countryStats = JsonConvert.DeserializeObject<CountryStats>(jsonContent);
            return countryStats;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data from JSON: {ex.Message}");
            return null;
        }
    }

    public Country GetCountryByName(Country.CountryName countryName)
    {
        return Countries.Find(country => String.Equals(country.Name.ToString(), countryName.ToString(), StringComparison.OrdinalIgnoreCase));
    }
}

public class Country
{
    public CountryName Name { get; set; }
    public int Manpower { get; set; }
    public int CivilianFactories { get; set; }
    public int MilitaryFactories { get; set; }
    public int NavalFactories { get; set; }
    public Resources Resources { get; set; }
    public Leaders Leaders { get; set; }

    public enum CountryName
    {
        UnitedStates,
        Germany,
        France,
        Italy,
        UnitedKingdom
    }
}

public class Resources
{
    public int Oil { get; set; }
    public int Steel { get; set; }
    public int Aluminum { get; set; }
    public int Rubber { get; set; }
}

public class Leaders
{
    public string Commander { get; set; }
    public string Advisor { get; set; }
}

public class NonPlayerCountryVariables
{
    public bool hasWargoal { get; set; }
}