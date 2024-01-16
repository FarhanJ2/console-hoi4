using System;
using System.Diagnostics;
public class Program
{
    // Country player is playing as
    public Country.CountryName selectedCountry;

    public static void Main(string[] args)
    {
        Program programInstance = new Program();
        programInstance.GameLoad();

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
        CountryLoad();
    }

    private void CountryLoad()
    {
        Console.WriteLine("Loading Country...");
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
        MenuOpen(selectedMenu);
        
    }

    private void MenuOpen(MenuHandle.MenuOptions menuName) 
    {
        MenuHandle menuHandle = new MenuHandle();
        switch (menuName)
        {
            case MenuHandle.MenuOptions.Government:
                menuHandle.Government(this);
                break;
            case MenuHandle.MenuOptions.Decisions:
                menuHandle.Decisions(this);
                break;
            case MenuHandle.MenuOptions.Research:
                menuHandle.Research(this);
                break;
            case MenuHandle.MenuOptions.Trade:
                menuHandle.Trade(this);
                break;
            case MenuHandle.MenuOptions.Production:
                menuHandle.Production(this);
                break;
            case MenuHandle.MenuOptions.RecruitAndDeploy:
                menuHandle.RecruitAndDeploy(this);
                break;
            case MenuHandle.MenuOptions.Logistics:
                menuHandle.Logistics(this);
                break;
            case MenuHandle.MenuOptions.Army:
                menuHandle.Army(this);
                break;
            case MenuHandle.MenuOptions.ListStats:
                menuHandle.ListStats(selectedCountry);
                break;      
        }
    }
}   