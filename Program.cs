using Constants;

public class Program
{
    public Country country;

    public static void Main(string[] args)
    {
        Program programInstance = new Program();
        programInstance.GameLoad();
    }

    private void GameLoad()
    {
        Console.WriteLine("HOI4 Loading...");
        Console.WriteLine("Please Select a Country to Choose From: ");
        
        for (int i = 0; i < GAME_VARS.countryNames.Length; i++) 
        {
            Console.WriteLine(i + ". " + GAME_VARS.countryNames[i]); 
        }
        
        int selection;
        while (!int.TryParse(Console.ReadLine(), out selection) || 
                selection < 0 || selection >= GAME_VARS.countryNames.Length)
        {
            Console.WriteLine("Invalid selection. Please choose a number from the list.");
        }
        
        string selectedCountry = GAME_VARS.countryNames[selection];
        country = new Country(selectedCountry);
        Console.WriteLine($"You have selected {selectedCountry} as your starting country...\nStarting Game...");
        CountryLoad();
    }

    private void CountryLoad()
    {
        Console.WriteLine("Loading Country...");
        Console.WriteLine("Select a Menu to Open");

        for (int i = 0; i < Menu.menuOptions.Length; i++) 
        {
            Console.WriteLine(i + ". " + Menu.menuOptions[i]); 
        }
        
        int selection;
        while (!int.TryParse(Console.ReadLine(), out selection) || 
                selection < 0 || selection >= Menu.menuOptions.Length)
        {
            Console.WriteLine("Invalid selection. Please choose a number from the list.");
        }
        
        string selectedMenu = Menu.menuOptions[selection];
        MenuOpen(selectedMenu);
        
    }

    private void MenuOpen(string menuName) {
        MenuHandle menuHandle = new MenuHandle();
        switch (menuName)
        {
            case "Government":
                menuHandle.Government(this);
                break;
            case "Decisions":
                menuHandle.Decisions(this);
                break;
            case "Research":
                menuHandle.Research(this);
                break;
            case "Trade":
                menuHandle.Trade(this);
                break;
            case "Production":
                menuHandle.Production(this);
                break;
            case "Recruit and Deploy":
                menuHandle.RecruitAndDeploy(this);
                break;
            case "Logistics":
                menuHandle.Logistics(this);
                break;
            case "Army":
                menuHandle.Army(this);
                break;
            case "List Stats":
                menuHandle.ListStats(this);
                break;      
        }
    }
}   