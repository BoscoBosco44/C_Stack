int[] zeroToNine = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

string[] names = {"Tim", "Martin", "Nikki", "Sata"};

bool[] arr = new bool[10];
int i = 0;
bool tf = true;
while(i < 10) {
    arr[i] = tf;

    i++;
    tf = !tf;
}
Console.WriteLine(arr); //wut?

List<string> iceream = new List<string>();
iceream.Add("Vanilla");
iceream.Add("Chocolate");
iceream.Add("Blue");
iceream.Add("Moose Tracks");
iceream.Add("Mint");

Console.WriteLine(iceream.Count);
Console.WriteLine(iceream[2]);

iceream.RemoveAt(2);
Console.WriteLine(iceream.Count);


Dictionary<string, string> dict = new Dictionary<string, string>();

int j = 0;
while(j < iceream.Count) {
    dict.Add(names[j], iceream[j]);
    j++;
}

foreach(KeyValuePair<string, string> entry in dict) {
    Console.WriteLine(entry);
}