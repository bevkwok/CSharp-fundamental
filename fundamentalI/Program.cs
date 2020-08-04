using System;

namespace fundamentalI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            for (int i = 1; i < 255; i++) {
                System.Console.WriteLine(i);
            }

            for (int j = 1; j <=100; j++) {
                if (j % 3 == 0 || j % 5 == 0){
                    System.Console.WriteLine(j);
                }
            }

            for (int x = 1; x <= 100; x++) {
                if (x % 3 == 0){
                    System.Console.WriteLine("Fizz");
                }
                if (x % 5 == 0){
                    System.Console.WriteLine("Bizz");
                }
                if (x % 3 == 0 && x % 5 == 0) {
                    System.Console.WriteLine("FizzBizz");
                }
            }

            int a = 1;
            while(a <= 100)
            {
                a++;
                if (a % 3 == 0){
                    System.Console.WriteLine("fizz");
                }
                if (a % 5 == 0){
                    System.Console.WriteLine("bizz");
                }
                if (a % 3 == 0 && a % 5 == 0) {
                    System.Console.WriteLine("fizzbizz");
                }
            }
        }

    }
}
