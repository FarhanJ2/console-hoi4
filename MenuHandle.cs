using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

public class MenuHandle
{
    CountryStats countryStats;

    public enum MenuOptions
    {
        TestAddNotification,
        Notifications,
        Government,
        Decisions,
        Research,
        Trade,
        Production,
        RecruitAndDeploy,
        Logistics,
        Army,
        ListStats,
        QuitandSave
    }

    public bool TestAddNotification()
    {
        string title = Console.ReadLine();
        string message = Console.ReadLine();

        
        Program.notifications.AddNotification(new Notification {
            Title = title,
            Message = message,
            Type = NotificationType.Event,
            Timestamp = new DateTime(1936, 1, 2)
        });
        return true;
    }

    public bool Notifications()
    {
        Program.notifications.OpenNotificationsLog();
        return true;
    }

    public bool Government(Program program)
    {
        return true;
    }

    public bool Decisions(Program program)
    {
        return true;
    }

    public bool Research(Program program)
    {
        return true;
    }

    public bool Trade(Program program)
    {
        return true;
    }

    public bool Production(Program program)
    {
        return true;
    }

    public bool RecruitAndDeploy(Program program)
    {
        return true;
    }

    public bool Logistics(Program program)
    {
        return true;
    }

    public bool Army(Program program)
    {
        return true;
    }

    public bool ListStats(Country.CountryName country)
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

        return true;
    }

    public bool QuitandSave()
    {
        Console.WriteLine("Saving Game...");
        // Implement SaveGame.cs function here to save and then make a load function to load on start
        return false;
    }

}