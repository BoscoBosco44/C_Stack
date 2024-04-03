
class Vehicle {

    string Name;
    int numPassengers;
    string Color;
    bool hasEngine;
    int milesTraveled = 0;


    //constructor:
    public Vehicle(string name, int numPass, string color, bool hasEng) {
        Name = name;
        numPassengers = numPass;
        Color = color;
        hasEngine = hasEng;
    }

    public Vehicle(string name, string color) {
        Name = name;
        numPassengers = 5;
        Color = color;
        hasEngine = true;
    }

    public string ShowInfo() {
        return $"{Name} is a greate vehicle that fits {numPassengers}, is bright {Color} and, dose it have an engine? {hasEngine}! It has gone {milesTraveled} miles";
    }

    public string Travel(int distance) {
        milesTraveled += distance;
        return $"{Name} has traveled {milesTraveled} miles";
    }
}