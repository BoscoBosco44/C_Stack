

class Coffee : Drink
{
    string roastValue;
    string beans;

    public override void ShowDrink() {
        Console.WriteLine("---------------");
        Console.WriteLine();

        Console.WriteLine(Name);
        Console.WriteLine(Color);
        Console.WriteLine(Temperature);
        Console.WriteLine(IsCarbonated);
        Console.WriteLine(Calories);
        Console.WriteLine(roastValue);
        Console.WriteLine(beans);
        Console.WriteLine();
    }

    public Coffee(string n, double t, int cal, string r, string b) : base(n, "brown", t, false, cal)
    {
        roastValue = r;
        beans = b;
    }
}