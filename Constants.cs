namespace Constants
{
    public class Country
    {
        public string Name { get; set; }
        public int Manpower { get; set; }
        public string Government { get; set; }
        public int WarSupport { get; set; }
        public int divisions { get; set; }

        private void returnCountryValues(string name)
        {
            switch (name)
            {       
                case "United States":
                    Manpower = 1000;
                    Government = "Democratic";
                    WarSupport = 5;
                    break;
                case "Germany":
                    Manpower = 2400124;
                    Government = "Fascist";
                    WarSupport = 50;
                    break;
                case "France":
                    Manpower = 1500000;
                    Government = "Democratic";
                    WarSupport = 7;
                    break;
                case "Italy":
                    Manpower = 1000000;
                    Government = "Fascist";
                    WarSupport = 60;
                    break;
                case "United Kingdom":
                    Manpower = 1000000;
                    Government = "Democratic";
                    WarSupport = 10;
                    break;
            }
        }

        public Country(string name)
        {
            Name = name;
            returnCountryValues(name);
        }
    }

    public static class GAME_VARS
    {
        public static string[] countryNames;
        public static int divisionManpower = 15000;

        static GAME_VARS()
        {
            countryNames = new string[] { "United States", "Germany", "France", "Italy", "United Kingdom" };
        }
    }

    public static class Menu
    {
        public static string[] menuOptions;

        static Menu()
        {
            menuOptions = new string[] { "Government", "Decisions", "Research", "Trade", "Production", "Recruit and Deploy", "Logistics", "Army", "List Stats" };
        }
    }
}

