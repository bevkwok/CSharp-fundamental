using System;
using System.Collections.Generic;

namespace hungrey_ninja
{
    class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;
        
        // add a constructor
        public Ninja()
        {
            calorieIntake = 0;
            FoodHistory = new List<Food>{};
        }
        
        // add a public "getter" property called "IsFull"
        public bool IsFull
        {
            get
            {
                if(calorieIntake > 1200){
                    return true;
                }
                return false;
            }
        }
        
        // build out the Eat method
        public void Eat(Food item)
        {
            if(calorieIntake < 1200){
                FoodHistory.Add(item);
                System.Console.WriteLine(FoodHistory);
                calorieIntake += item.Calories;
                System.Console.WriteLine(calorieIntake);
                if(item.IsSpicy == true){
                    System.Console.WriteLine($"{item.Name} is so spicy");
                }
                else if (item.IsSweet == true){
                    System.Console.WriteLine($"{item.Name} is so sweet");
                } else if (item.IsSweet == true && item.IsSpicy == true){
                    System.Console.WriteLine($"{item.Name} is so sweet and spicy");
                } else {
                    System.Console.WriteLine($"{item.Name} is not sweet and not spicy");
                }
            } else {
                System.Console.WriteLine("Ninja can't eat anymore!");
            }
        }
    }
}