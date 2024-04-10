

public class Wine : Drink
{
    string region;
    int year;

    public override void ShowDrink() {
        Console.WriteLine("---------------");
        Console.WriteLine();

        Console.WriteLine(Name);
        Console.WriteLine(Color);
        Console.WriteLine(Temperature);
        Console.WriteLine(IsCarbonated);
        Console.WriteLine(Calories);
        Console.WriteLine(region);
        Console.WriteLine(year);
        Console.WriteLine();
    }

    public Wine(string n, string c, int cal, string r, int y) : base(n, c, 55, false, cal)
    {
        region = r;
        year = y;
    }
}