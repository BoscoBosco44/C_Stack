

class Ranged : Enemy
{
    int Distance;
    new protected List<Attack> AttackList;
    new public void AddAttack(Attack name) {
        AttackList.Add(name);
    }

    public string Attack() {
        Random rand = new Random();
        if(AttackList.Count > 0 && Distance > 10)
            return $"{AttackList[rand.Next(0, AttackList.Count)].Name}"; 
        else if(AttackList.Count > 0 && Distance <= 10)
            return $"{Name} is {Distance} away and can not attack";
        else
            return $"{Name} has no attacks";
    }

    public string Dash() 
    {
        Distance = 20;
        return $"{Name} Dashes 20 spaces away";
    }
//----------------------------------------------------------
    public Ranged() : base("RangedFighter")
    {
        AttackList = new List<Attack>();
        Distance = 5;

        Attack ShootArrow = new Attack("Shoot an Arrow", 20);
        Attack KnifeThrow = new Attack("Throw a Knife", 15);

        AddAttack(ShootArrow);
        AddAttack(KnifeThrow);
    }
}
