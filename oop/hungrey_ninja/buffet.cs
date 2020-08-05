using System;
using System.Collections.Generic;

namespace hungrey_ninja
{
    class Buffet
    {
        public List<Food> Menu;
        
        //constructor
        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("bread", 300, false, false),
                new Food("chicken", 380, false, false),
                new Food("beef", 500, true, false),
                new Food("mushroom", 260, false, false),
                new Food("pasta", 600, true, false),
                new Food("broccoli", 310, false, true),
                new Food("ice cream", 660, false, true),
            };
        }
        
        public Food Serve()
        {
            Random rand = new Random();
            for(int i = 0; i < Menu.Count; i++)
            {
                System.Console.WriteLine(Menu[rand.Next(0,Menu.Count)]);
            }
            return Menu[rand.Next(0,Menu.Count)];
        }
    }
}