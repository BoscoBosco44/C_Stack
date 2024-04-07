

class Magic : Enemy 
{
    // new protected List<Attack> AttackList;
    new public void AddAttack(Attack name) {
        AttackList.Add(name);
    }

    public string Heal(Enemy Target) {
        Target.health = Target.health + 40;
        return $"{Target.Name} has been healed by {Name} to {Target.health} health";
    }



    public Magic() : base("MagicMaster")
    {
        AttackList = new List<Attack>();

        Attack Fireball = new Attack("Fireball", 25);
        Attack Lightning = new Attack("Lightning Bolt", 20);
        Attack StaffStrike = new Attack("Staff Strike", 10);
        AddAttack(Fireball);
        AddAttack(Lightning);
        AddAttack(StaffStrike);
    }


}