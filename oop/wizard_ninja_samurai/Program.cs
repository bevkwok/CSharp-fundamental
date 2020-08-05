using System;

namespace wizard_ninja_samurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Human human1 = new Human("Amy");
            Human human2 = new Human("Tom");
            Wizard wizard1 = new Wizard("Wizard-Will");
            Ninja ninja1 = new Ninja("Ninja-Nick");
            Samurai samurai1 = new Samurai("Samurai-Sam");

            human1.Attack(human2);
            wizard1.Attack(human2);
            wizard1.Heal(human2);
            ninja1.Attack(human2);
            ninja1.Steal(human2);
            samurai1.Attack(human2);
            samurai1.Meditate();



        }
    }
}
