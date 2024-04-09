List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
// IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

//1.
String chileErup = eruptions.FirstOrDefault(e => e.Location == "Chile").ToString();
Console.WriteLine(chileErup);
Console.WriteLine();
Console.WriteLine("-----------------------------------------");


//2. 
string hawaiianIS = eruptions.FirstOrDefault(e => e.Location == "Hawaiian Is").ToString();
if(hawaiianIS != null)
    Console.WriteLine(hawaiianIS);
else
    Console.WriteLine("No Hawaiian Is Eruption found");
Console.WriteLine();
Console.WriteLine("-----------------------------------------");

//3.
Eruption? greenlandErupt = eruptions.FirstOrDefault(e => e.Location == "Greenland");
if(greenlandErupt != null)
    Console.WriteLine(greenlandErupt);
else
    Console.WriteLine("No greenland Eruption found");
Console.WriteLine();
Console.WriteLine("-----------------------------------------");

//4.
Eruption? firstAfter1900NewZ = eruptions.FirstOrDefault(e => e.Location == "New Zealand" && e.Year > 1900);
Console.WriteLine(firstAfter1900NewZ);

Console.WriteLine();
Console.WriteLine("-----------------------------------------");

//5.
List<Eruption>? eList = eruptions.Where(e => e.ElevationInMeters > 2000).ToList();
PrintEach(eList);

Console.WriteLine();
Console.WriteLine("-----------------------------------------");

//6.
List<Eruption>? nameL = eruptions.Where(e => e.Volcano[0] == 'L').ToList();
PrintEach(nameL);

// Console.WriteLine();
// Console.WriteLine("-----------------------------------------");

//7.
int? highestElevation = eruptions.Max(e => e.ElevationInMeters);
Console.WriteLine(highestElevation);

Console.WriteLine();
Console.WriteLine("-----------------------------------------");

//8.
int? highestElevation2 = eruptions.Max(e => e.ElevationInMeters);
Console.WriteLine(highestElevation2);

Console.WriteLine();
Console.WriteLine("-----------------------------------------");

// //9.
Eruption highEl = eruptions.Where(e => e.ElevationInMeters == highestElevation).First();
string? name = highEl.Volcano;
Console.WriteLine(name);

Console.WriteLine(highEl.ToString());

Console.WriteLine();
Console.WriteLine("-----------------------------------------");

//10.
IEnumerable<Eruption> all = eruptions.OrderBy(e => e.Volcano);
PrintEach(all);

//11.
int sum = eruptions.Sum(e => e.ElevationInMeters);
Console.WriteLine(sum);

//12.
bool Eruption2000 = eruptions.Any(e => e.Year == 2000);
Console.WriteLine("Was there an eruption in 2000: ");
Console.WriteLine(Eruption2000);



//13.
IEnumerable<Eruption> take3 = eruptions.Where(e => e.Type == "Stratovolcano").Take(3);
PrintEach(take3);


//14.
IEnumerable<Eruption> b41000 = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano);
PrintEach(b41000);



List<string> b410002 = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano).Select(e => e.Volcano).ToList();
PrintEachList(b410002);








// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
static void PrintEachList(List<string> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (string item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
