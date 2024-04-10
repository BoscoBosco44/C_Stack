

Soda coke = new Soda("Coke", "brown", 40, 140, false);
Coffee latte = new Coffee("Latte", 40, 300, "medium", "brazil beans");
Wine leWine = new Wine("leWine", "red", 130, "tuscany", 1902);

List<Drink> AllBeverages = [coke, latte, leWine];

AllBeverages.ForEach(delegate(Drink bev) {
    bev.ShowDrink();
});

//Coffee MyDrink = new Soda();

//this is trying to create a soda object with type coffee