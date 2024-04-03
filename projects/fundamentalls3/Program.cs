static void PrintList(List<string> leList) {
    leList.ForEach(delegate(string name) 
    {
        Console.WriteLine(name);
    });
}
static void PrintIntList(List<int> leList) {
    leList.ForEach(delegate(int name) 
    {
        Console.WriteLine(name);
    });
}

List<string> TestStringList = new List<string>() {"Paul", "Peter", "mary", "luca"};
PrintList(TestStringList);

static void SumOfNumbers(List<int> IntList)
{
    int sum = 0;
    IntList.ForEach(delegate(int num) {
        sum = sum + num;
    });
    Console.WriteLine(sum);
}

List<int> TestThisInt = new List<int>() {2,7,12,9,3};
SumOfNumbers(TestThisInt);

static int FindMax(List<int> IntList) {
    int max = 0;
    IntList.ForEach(delegate(int num) {
        if(num > max) {
            max = num;
        }
    });
    return max;
}

List<int> TestIntList2 = new List<int> {-9,12,10,3,17,5};
Console.WriteLine(FindMax(TestIntList2));

static List<int> SquareValues(List<int> IntList) {
    List<int> squares = new List<int> {};
    for(int i = 0; i < IntList.Count; i++) {
        squares.Add(IntList[i] * IntList[i]);
    }
    return squares;
}

List<int> TextIntList3 = new List<int> {1,2,3,4,5};
PrintIntList(SquareValues(TextIntList3));

static int[] NonNegatives(int[] IntArray)
{
    for(int i = 0; i < IntArray.Length; i++) {
        if(IntArray[i] < 0) {
            IntArray[i] = 0;
        }
    }
    return IntArray;
}
int[] TestIntArray = new int[] {-1,2,3,-4,5};
int[] output = NonNegatives(TestIntArray);

int j = 0;
string str = "";
while(j < TestIntArray.Length) {
    str = str + " " + output[j];
    j++;
}
Console.WriteLine(str);

static void PrintDict(Dictionary<string, string> myDict) {
    foreach(KeyValuePair<string, string> name in myDict) {
        Console.WriteLine($"Key: {name.Key}, Name: {name.Value}");
    }
}

Dictionary<string, string> testDict = new Dictionary<string, string>();
testDict.Add("HeroName", "I ron Man");
testDict.Add("RealName", "Tony Stark");
testDict.Add("Powers", "Money and intelligence");
PrintDict(testDict);

static bool FindKey(Dictionary<string, string> myDict, string SearchTerm) {
    foreach(KeyValuePair<string, string> name in myDict) {
        if(name.Key == SearchTerm)
            { return true; }
    }
    return false;
}


Console.WriteLine(FindKey(testDict, "RealName"));
Console.WriteLine(FindKey(testDict, "Name"));
Console.WriteLine();


// Ex: Given ["Julie", "Harold", "James", "Monica"] and [6,12,7,10], return a dictionary
// {
//	"Julie": 6,
//	"Harold": 12,
//	"James": 7,
//	"Monica": 10
// } 
static Dictionary<string,int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    Dictionary<string, int> gen = new Dictionary<string, int>();
    for(int i = 0; i < Numbers.Count; i++) {
        gen.Add(Names[i], Numbers[i]);
    }

    //printing in same function
    foreach(KeyValuePair<string, int> person in gen) {
        Console.WriteLine($"{person.Key}: {person.Value}");
    }
    return gen;
}
// We've shown several examples of how to set your tests up properly, it's your turn to set it up!
// Your test code here

List<string> naaames = ["Julie", "Harold", "James", "Monica"];
List<int> ages = [6,12,7,10];
GenerateDictionary(naaames, ages);
