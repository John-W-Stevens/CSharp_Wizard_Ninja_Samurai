using System;

namespace WizardNinjaSamurai
{

    public class Human
    {

        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health;

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        // Construtor 1
        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }

        // Construtor 2
        public Human(string name, int strength, int intelligence, int dexterity, int health)
        {
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
            Health = health;
        }

        public virtual int Attack(Human target)
        {
            int Damage = this.Strength * 5;
            target.Health -= Damage;
            return target.Health;
        }

    }

    // Create a class for a Ninja, a Wizard, and a Samurai. For this assignment, you will need to modify your Human class.

    public class Wizard : Human
    {

        public Wizard(string name) : base(name)
        {
            // Wizard should have a default health of 50 and Intelligence of 25
            Health = 50;
            Intelligence = 25;
        }
        // Provide an override Attack method to Wizard, which reduces the target by 5 * Intelligence and heals the Wizard by the amount of damage dealt
        public override int Attack(Human target)
        {
            int Damage = this.Intelligence * 5;
            target.Health -= Damage;
            this.Health += Damage;
            return target.Health;
        }
        // Wizard should have a method called Heal, which when invoked, heals a target Human by 10 * Intelligence
        public void Heal(Human target)
        {
            target.Health += 10 * this.Intelligence;
        }

    }

    public class Ninja : Human
    {
        public Ninja(string name) : base(name)
        {
            // Ninja should have a default dexterity of 175
            Dexterity = 175;
        }
        // Provide an override Attack method to Ninja, which reduces the target by 5 * Dexterity and a 20% chance of dealing an additional 10 points of damage.
        public override int Attack(Human target)
        {
            Random rand = new Random();       
            int Damage = this.Dexterity * 5;
            int Crit = rand.Next(0, 5);
            if (Crit == 1) { Damage += 10; }
            target.Health -= Damage;
            return target.Health;   
        }
        // Ninja should have a method called Steal, reduces a target Human's health by 5 and adds this amount to its own health.
        public void Steal(Human target)
        {
            target.Health -= 5;
            this.Health += 5;
        }
    }

    public class Samurai : Human
    {
        public Samurai(string name) : base(name)
        {
            // Samurai should have a default health of 200
            Health = 200;
        }
        // Provide an override Attack method to Samurai, which calls the base Attack and reduces the target to 0 if it has less than 50 remaining health points.
        public override int Attack(Human target)
        {
            int TargetHealth = base.Attack(target);
            if (TargetHealth < 50)
            {
                target.Health = 0;
            }
            return target.Health;
        }
        // Samurai should have a method called Meditate, which when invoked, heals the Samurai back to full health
        public void Meditate()
        {
            this.Health = 200;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // Test wizard Attack method:
            Wizard GoodWizard = new Wizard("Dumbledore");
            Wizard BadWizard = new Wizard("Saruman");
            // Console.WriteLine($"{GoodWizard.Name}, {GoodWizard.Health}");
            // Console.WriteLine($"{BadWizard.Name}, {BadWizard.Health}");
            // GoodWizard.Attack(BadWizard);
            // Console.WriteLine($"{GoodWizard.Name}, {GoodWizard.Health}");
            // Console.WriteLine($"{BadWizard.Name}, {BadWizard.Health}");

            // Test wizard Attack method:
            Ninja GoodNinja = new Ninja("Jackie Chan");
            Ninja BadNinja = new Ninja("Jet Lee");
            // Console.WriteLine($"{GoodNinja.Name} {GoodNinja.Health}");
            // Console.WriteLine($"{BadNinja.Name} {BadNinja.Health}");
            // GoodNinja.Attack(BadNinja);
            // Console.WriteLine($"{GoodNinja.Name} {GoodNinja.Health}");
            // Console.WriteLine($"{BadNinja.Name} {BadNinja.Health}");

            // Test Samurai Attack method:
            Samurai GoodSamurai = new Samurai("Chuck Norris");
            Samurai BadSamurai = new Samurai("Darth Vader");
            BadSamurai.Health = 64;

            // Console.WriteLine($"{GoodSamurai.Name} {GoodSamurai.Health}");
            // Console.WriteLine($"{BadSamurai.Name} {BadSamurai.Health}");
            // GoodSamurai.Attack(BadSamurai);
            // Console.WriteLine($"{GoodSamurai.Name} {GoodSamurai.Health}");
            // Console.WriteLine($"{BadSamurai.Name} {BadSamurai.Health}");

            // Test Wizard Heal method
            GoodWizard.Heal(GoodSamurai);
            Console.WriteLine(GoodSamurai.Health);

            // Test Samurai Mediate method
            BadSamurai.Meditate();
            Console.WriteLine(BadSamurai.Health);

            // Test Ninja Steal method
            GoodNinja.Steal(BadWizard);
            Console.WriteLine(GoodNinja.Health);
            Console.WriteLine(BadWizard.Health);
        }
    }
}
