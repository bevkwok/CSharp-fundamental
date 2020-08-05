using System;

namespace wizard_ninja_samurai
{
    class Wizard : Human
    {
        public Wizard(string name): base(name)
        {
            Intelligence = 25;
            health = 50;
        }

        public override int Attack(Human target)
        {
            int dmg = Intelligence * 5;
            target.health -= dmg;
            health += dmg;
            System.Console.WriteLine($"{target.Name} was attacked by {this.Name}. {target.Name}'s health decreased to {target.health} and {this.Name}'s health increase to {this.health}");
            return target.health;
        }

        public int Heal(Human target)
        {
            target.health += 10 * Intelligence;
            System.Console.WriteLine($"{this.Name} healed {target.Name}; {target.Name}'s health increase to {target.health}");
            return target.health;
        }
    }

    class Ninja : Human
    {
        public Ninja(string name): base(name)
        {
            Dexterity = 175;
        }

        public override int Attack(Human target)
        {
            int dmg = Dexterity * 5;
            Random rand = new Random();
            for (int i = 0; i <= 1; i++)
            {
                System.Console.WriteLine(rand.Next(0,5));
                if (rand.Next(0,5) == 5)
                {
                    dmg += 10;
                }
            }
            target.health -= dmg;
            System.Console.WriteLine($"{target.Name} was attacked by {this.Name}. {target.Name}'s health decreased to {target.health}.");
            return target.health;
        }

        public int Steal(Human target)
        {
            target.health -= 5;
            health += 5;
            System.Console.WriteLine($"{target.Name}'s health increase to  {target.health} and {this.Name}'s health increase to {this.health} ");
            return target.health;
        }
    }

    class Samurai : Human
    {
        public Samurai(string name): base(name)
        {
            health = 200;
        }

        public override int Attack(Human target)
        {
            if (target.health < 50){
                target.health = 0;
                System.Console.WriteLine($"{target.Name} is killed by {this.Name}");
                return target.health;
            } else {
                int dmg = Strength * 5;
                target.health -= dmg;
                health += dmg;
                System.Console.WriteLine($"{target.Name} was attacked by {this.Name}. {target.Name}'s health decreased to {target.health}.");
                return target.health;
            }
            
        }
        public int Meditate()
        {
            health = 200;
            System.Console.WriteLine($"{this.Name}'s health is back to full");
            return health;
        }
    }
}