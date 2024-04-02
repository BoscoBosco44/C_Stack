// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// string name = "boscoBosco";

// char name2 = 'b';

// Console.WriteLine($"name: {name}, name2: {name2}");


for(int i = 1; i <= 255; i++) {
    Console.WriteLine(i);
}

Random rand = new Random();
int sum = 0;
for(int i = 0; i < 5; i++) {
    sum = sum + rand.Next(5, 11);
}
Console.WriteLine(sum);

for(int i = 1; i <= 100; i++) {
    if((i % 3 == 0 && !(i % 5 == 0) ) || (i % 5 == 0 && !(i % 3 == 0))) {
        Console.WriteLine(i);
    }
}

for(int i = 1; i <= 100; i++) {
    if(i % 3 == 0 && !(i % 5 == 0)) {
        Console.WriteLine("Fizz");
    }
    else if (i % 5 == 0 && !(i % 3 == 0)) {
        Console.WriteLine("buzz");
    }
    else if (i % 3 == 0 && i % 5 ==0) {
        Console.WriteLine("FizzBuzz");
    }
}