using System;
using System.Diagnostics;
public class Program
{
    // Country player is playing as
    public static Country.CountryName selectedCountry;
    // Notifications list to add to
    public static Notifications notifications = new Notifications();
    // public static FocusTree focusTree = new FocusTree(); // TODO: Uncomment this when the variable to send is found

    public static void Main(string[] args)
    {
        notifications.AddNotification(new Notification {
            Title = "Welcome to HOI4 Console App",
            Message = "Welcome to the HOI4 Console App.",
            Type = NotificationType.Event,
            Timestamp = new DateTime(1936, 1, 1)
        });

        notifications.AddNotification(new Notification {
            Title = "Testing Notifications",
            Message = "This is a warning",
            Type = NotificationType.Warning,
            Timestamp = new DateTime(1936, 1, 1)
        });

        notifications.AddNotification(new Notification {
            Title = "Testing Notifications",
            Message = "This is an Error",
            Type = NotificationType.Error,
            Timestamp = new DateTime(1936, 1, 1)
        });

        notifications.AddNotification(new Notification {
            Title = "Testing Notifications",
            Message = "This is an Error",
            Type = NotificationType.Error,
            Timestamp = new DateTime(1936, 1, 1)
        });

        notifications.AddNotification(new Notification {
            Title = "Testing Notifications",
            Message = "This is an Error",
            Type = NotificationType.Error,
            Timestamp = new DateTime(1936, 1, 1)
        });

        Program programInstance = new Program();
        programInstance.GameLoad();

        // Timer logic
        Game game = new Game();
        game.Start();
    }

    private void GameLoad()
    {
        Console.WriteLine("HOI4 Loading...");
        // Create new game or save game logic later

        Console.WriteLine("Please Select a Country to Choose From: ");
        
        foreach (string country in Enum.GetNames(typeof(Country.CountryName)))
        {
            Console.WriteLine($"{(int)Enum.Parse(typeof(Country.CountryName), country)}. {country}");
        }

        int selection;
        while (!int.TryParse(Console.ReadLine(), out selection) || 
                selection < 0 || selection >= Enum.GetNames(typeof(Country.CountryName)).Length)
        {
            Console.WriteLine("Invalid selection. Please choose a number from the list.");
        }
        
        selectedCountry = (Country.CountryName)Enum.Parse(typeof(Country.CountryName), Enum.GetNames(typeof(Country.CountryName))[selection]);
        Console.WriteLine($"You have selected {selectedCountry} as your starting country...\nStarting Game...");
        Console.WriteLine("Loading Country...");
        MenuLoad();
    }

    private void MenuLoad()
    {
        Console.WriteLine("Select a Menu to Open");

        foreach (string menuOption in Enum.GetNames(typeof(MenuHandle.MenuOptions)))
        {
            Console.WriteLine($"{(int)Enum.Parse(typeof(MenuHandle.MenuOptions), menuOption)}. {menuOption}");
        }
        
        int selection;
        while (!int.TryParse(Console.ReadLine(), out selection) || 
                selection < 0 || selection >= Enum.GetNames(typeof(MenuHandle.MenuOptions)).Length)
        {
            Console.WriteLine("Invalid selection. Please choose a number from the list.");
        }
        
        MenuHandle.MenuOptions selectedMenu = (MenuHandle.MenuOptions)Enum.Parse(typeof(MenuHandle.MenuOptions), Enum.GetNames(typeof(MenuHandle.MenuOptions))[selection]);
        if (MenuOpen(selectedMenu)) MenuLoad();
    }

    private bool MenuOpen(MenuHandle.MenuOptions menuName) 
    {
        MenuHandle menuHandle = new MenuHandle();
        switch (menuName)
        {
            case MenuHandle.MenuOptions.TestAddNotification:
                return menuHandle.TestAddNotification();
            case MenuHandle.MenuOptions.Notifications:
                return menuHandle.Notifications();
            case MenuHandle.MenuOptions.Government:
                return menuHandle.Government(this);
            case MenuHandle.MenuOptions.Decisions:
                return menuHandle.Decisions(this);
            case MenuHandle.MenuOptions.Research:
                return menuHandle.Research(this);
            case MenuHandle.MenuOptions.Trade:
                return menuHandle.Trade(this);
            case MenuHandle.MenuOptions.Production:
                return menuHandle.Production(this);
            case MenuHandle.MenuOptions.RecruitAndDeploy:
                return menuHandle.RecruitAndDeploy(this);
            case MenuHandle.MenuOptions.Logistics:
                return menuHandle.Logistics(this);
            case MenuHandle.MenuOptions.Army:
                return menuHandle.Army(this);
            case MenuHandle.MenuOptions.ListStats:
                return menuHandle.ListStats(selectedCountry); 
        }

        return false;
    }
}   