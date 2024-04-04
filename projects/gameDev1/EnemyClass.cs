//name, health, attackList(empty)
//constructor: need name, health = 100
//methods: randomAttack

class Enemy {
    string Name;
    int health;
    List<Attack> AttackList;

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

    public void addAttack(Attack name) {
        AttackList.Add(name);
    }
}