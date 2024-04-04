Enemy badGuy = new Enemy("Bad Guy");

Attack facePunch = new Attack("Face Punch", 7);
Attack stab = new Attack("Stab", 11);
Attack nuke = new Attack("Nuke", 10000);

badGuy.addAttack(facePunch);
badGuy.addAttack(stab);
badGuy.addAttack(nuke);

Console.WriteLine(badGuy.RandomAttack());
Console.WriteLine(badGuy.RandomAttack());
Console.WriteLine(badGuy.RandomAttack());
Console.WriteLine(badGuy.RandomAttack());
Console.WriteLine(badGuy.RandomAttack());
Console.WriteLine(badGuy.RandomAttack());
Console.WriteLine(badGuy.RandomAttack());