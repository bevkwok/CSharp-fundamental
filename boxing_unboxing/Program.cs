using System;
using System.Collections.Generic;

namespace boxing_unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> boxinglist = new List<object>();

            boxinglist.Add(7);
            boxinglist.Add(28);
            boxinglist.Add(-1);
            boxinglist.Add(true);
            boxinglist.Add("chair");

            int sum = 0;
            foreach (object item in boxinglist) {
                
                System.Console.WriteLine(item);
                if (item is int) {
                    sum = sum + (int)item;
                }
            }
            System.Console.WriteLine(sum);
        }
    }
}
