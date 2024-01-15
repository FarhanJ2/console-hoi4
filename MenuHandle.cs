public class MenuHandle
{
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

    public void ListStats(Program program)
    {
        Console.WriteLine($"Country: {program.country.Name}");
        Console.WriteLine($"Manpower: {program.country.Manpower}");
        Console.WriteLine($"War Support: {program.country.WarSupport}%");
    }
}