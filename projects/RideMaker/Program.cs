

Vehicle prius = new Vehicle("Prius", "blue");
Vehicle Tesla = new Vehicle("Tesla", "white");
Vehicle MonsterTruck = new Vehicle("MonsterTruck", 1, "green", true);
Vehicle Moped = new Vehicle("Moped", 2, "baby blue", true);

List<Vehicle> vehicleList = [prius, Tesla, MonsterTruck, Moped];

for(int i = 0; i < vehicleList.Count; i++) {
    Console.WriteLine(vehicleList[i].ShowInfo());
}

Console.WriteLine(MonsterTruck.Travel(100));

Console.WriteLine(MonsterTruck.ShowInfo());