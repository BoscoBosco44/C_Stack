


using System.Security.Cryptography.X509Certificates; //wtf is this??

class Melee : Enemy 
{

    new public List<Attack> AttackList;
    new public void AddAttack(Attack name) {
        AttackList.Add(name);
    }

        public void Rage(Attack atk) {
            Console.WriteLine($"{Name} is inraged and dose a {atk.Name} for {atk.damageAmount + 10} dmg!");
        }


    public Melee() : base("MeleeFighter")
    {
        // AttackList = new List<Attack>();
        Attack Punch = new Attack("Punch", 20);
        Attack Kick = new Attack("Kick", 15);
        Attack Tackle = new Attack("Tackle", 25);
        AddAttack(Punch);
        AddAttack(Kick);
        AddAttack(Tackle);

    }


}