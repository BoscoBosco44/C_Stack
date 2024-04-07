//name, health, attackList(empty)
//constructor: need name, health = 100
//methods: randomAttack

public abstract class Enemy {
    public string Name;
    public int health;
    public List<Attack> AttackList;

    public Enemy(string name) {
        Name = name;
        health = 100;
        AttackList = [];
    }

    public string RandomAttack() {
        Random rand = new Random();
        if(AttackList.Count > 0)
            return $"{AttackList[rand.Next(0, AttackList.Count)].Name}"; 
        else
            return $"{Name} has no attacks";
    }

    public void AddAttack(Attack name) {
        AttackList.Add(name);
    }

    public void PreformAttack(Enemy Target, Attack ChosenAttack)
    {
        Target.health = Target.health - ChosenAttack.damageAmount;
        Console.WriteLine($"{Name} attacks {Target.Name}, dealing {ChosenAttack.damageAmount} damage and reducing {Target.Name}'s health to {Target.health}!!");
    }
}