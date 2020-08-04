using System;
using System.Collections.Generic;

namespace collections_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Declaring an array of length of 10
            int[] intArr;
            intArr = new int[] {0,1,2,3,4,5,6,7,8,9};

            string[] strArr;
            strArr = new string[] {"Tim", "Martin", "Nikki", "Sara" };

            bool[] boolArr = { true,false,true,false,true,false,true,false,true,false,};

            List<string> icecream = new List<string> { "strawberry", "cookies and cream", "green tea", "vanilla", "chocolate" };
            System.Console.WriteLine(icecream.Count);
            System.Console.WriteLine(icecream[2]);
            icecream.RemoveAt(2);
            System.Console.WriteLine(icecream.Count);

            Dictionary<string,string> people = new Dictionary<string,string>();
            Random rand = new Random();

            foreach (string name in strArr) {
                people.Add(name, icecream[rand.Next(0,icecream.Count)]);
            }

            foreach(var entry in people){
                System.Console.WriteLine(entry.Key + " loves " + entry.Value);
            }


        }
    }
}
