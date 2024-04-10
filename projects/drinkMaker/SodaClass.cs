


class Soda : Drink
{
    //feilds
    public bool IsDiet;

    public override void ShowDrink() {
        Console.WriteLine("---------------");
        Console.WriteLine();

        Console.WriteLine(Name);
        Console.WriteLine(Color);
        Console.WriteLine(Temperature);
        Console.WriteLine(IsCarbonated);
        Console.WriteLine(Calories);
        Console.WriteLine(IsDiet);
        Console.WriteLine();
    }


    //constructors
    public Soda(string n, string c, double t, int cals, bool d) : base(n, c, t, true, cals) 
    {
        IsDiet = d;
    }
}