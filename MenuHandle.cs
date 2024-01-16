public class MenuHandle
{
    CountryStats countryStats;

    public enum MenuOptions
    {
        Government,
        Decisions,
        Research,
        Trade,
        Production,
        RecruitAndDeploy,
        Logistics,
        Army,
        ListStats
    }

    public void Government(Program program)
    {

    }

    public void Decisions(Program program)
    {

    }

    public void Research(Program program)
    {

    }

    public void Trade(Program program)
    {

    }

    public void Production(Program program)
    {

    }

    public void RecruitAndDeploy(Program program)
    {

    }

    public void Logistics(Program program)
    {

    }

    public void Army(Program program)
    {}

    public void ListStats(Country.CountryName country)
    {
        Console.WriteLine(country);
        CountryStats countryStats = CountryStats.LoadFromJson(Constants.filePathToCountryStats);

        if (countryStats != null)
        {
            Country playerCountry = countryStats.GetCountryByName(country);

            if (playerCountry != null)
            {
                // Access the country information
                Console.WriteLine($"Country: {playerCountry.Name}");
                Console.WriteLine($"Manpower: {playerCountry.Manpower}");
                Console.WriteLine($"Civilian Factories: {playerCountry.CivilianFactories}");
                // Add more properties as needed

                // Access resources
                Console.WriteLine($"Oil: {playerCountry.Resources.Oil}");
                Console.WriteLine($"Steel: {playerCountry.Resources.Steel}");
                // Add more resource properties as needed

                // Access leaders
                Console.WriteLine($"Commander: {playerCountry.Leaders.Commander}");
                Console.WriteLine($"Advisor: {playerCountry.Leaders.Advisor}");
                // Add more leader properties as needed
            }
            else
            {
                Console.WriteLine("Country not found.");
            }
        }
        else
        {
            Console.WriteLine("Country stats not found.");
        }

        Console.ReadLine();
    }


}