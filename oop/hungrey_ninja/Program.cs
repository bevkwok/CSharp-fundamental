using System;
using System.Collections.Generic;

namespace hungrey_ninja
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Ninja ninja_a = new Ninja();

            Buffet buffet_a = new Buffet();

            
            if(ninja_a.IsFull == false){
                ninja_a.Eat(buffet_a.Serve());
            }
            else{
                System.Console.WriteLine("Ninja can't eat anymore!");
            }
        }
    }
}
