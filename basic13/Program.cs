using System;
using System.Collections.Generic;

namespace basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello");
            int[] numbers;
            numbers = new int[] {2,4,6,8,1};
            ShiftValues(numbers);
        }
        public static void PrintNumbers()
        {
            // Print all of the integers from 1 to 255.
            for(int i = 1; i <=255; i++){
                System.Console.WriteLine(i);
            }
        }
        public static void PrintOdds()
        {
            // Print all of the odd integers from 1 to 255.
            for(int i = 1; i <=255; i++){
                if (i % 2 != 0){
                    System.Console.WriteLine(i);
                }
                
            }
        }
        public static void PrintSum()
        {
            int sum = 0;
            // Print all of the numbers from 0 to 255, 
            // but this time, also print the sum as you go. 
            // For example, your output should be something like this:
            for(int i = 1;i <=255; i++){
                sum += i;
                System.Console.WriteLine("New number: " + i + "Sum: " + sum);
            }
            // New number: 0 Sum: 0
            // New number: 1 Sum: 1
            // New Number: 2 Sum: 3
        }
        public static void LoopArray(int[] numbers)
        {
            // Write a function that would iterate through each item of the given integer array and 
            // print each value to the console. 
            foreach(int num in numbers){
                System.Console.WriteLine(num);
            }
        }
        public static int FindMax(int[] numbers)
        {
            int max = 0;
            foreach(int num in numbers){
                if(num > max){
                    max = num;
                }
            }
            System.Console.WriteLine(max);
            return max;
        }
        public static void GetAverage(int[] numbers)
        {
            int max = 0;
            int avg = numbers.Length;
            foreach(int num in numbers){
                if(num > max){
                    max = num;
                }
            }
            System.Console.WriteLine(avg);
        }
        public static int[] OddArray()
        {   
            List<int> newArr = new List<int>();
            for(int i = 1; i <= 255; i++){
                if( i % 2 != 0){
                    newArr.Add(i);
                }
            }
            System.Console.WriteLine(newArr.ToArray());
            return newArr.ToArray();
        }
        public static int GreaterThanY(int[] numbers, int y)
        {
            int count = 0;
            foreach(int x in numbers){
                if(x > y){
                    count++;
                }
            }
            System.Console.WriteLine(count);
            return count;
        }
        public static void SquareArrayValues(int[] numbers)
        {
            for(int i = 0; i<numbers.Length; i++){
                numbers[i] = numbers[i] * numbers[i];
                System.Console.WriteLine(numbers[i]);
            }
            System.Console.WriteLine(numbers);
        }
        public static void EliminateNegatives(int[] numbers)
        {
            for(int i = 0; i<numbers.Length; i++){
                if(numbers[i] < 0){
                    numbers[i] = 0;
                    System.Console.WriteLine(numbers[i]);
                }
            }
            System.Console.WriteLine(numbers);
        }
        public static void MinMaxAverage(int[] numbers)
        {
            int max = numbers[0];
            int min = numbers[0];
            int sum = numbers[0];
            int avg = sum/numbers.Length;
            for(int i = 1; i<numbers.Length; i++){
                sum += numbers[i];
                if(numbers[i] > max){
                    max = numbers[i];
                }
                if(numbers[i] < min){
                    min = numbers[i];
                }
            }
            System.Console.WriteLine(max +","+ min +","+ sum/numbers.Length);
        }
        public static void ShiftValues(int[] numbers)
        {
            numbers[numbers.Length-1] = 0;
            for(int i = 0; i<numbers.Length-1; i++){
                numbers[i] = numbers[i+1];
                System.Console.WriteLine(numbers[i]);
            }
        }
        public static object[] NumToString(int[] numbers)
        {
            string dojo = "dojo";

        }
        return numbers[i];
    }
}
