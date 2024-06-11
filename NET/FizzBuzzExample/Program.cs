using System;

namespace FizzBuzz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Prompt the user to input the lower and upper values to play with

            Console.Write("Please enter a valid lower limit: ");
            string userIn = Console.ReadLine();
            int lower = Int32.Parse(userIn);

            Console.Write("Please enter a valid upper limit: ");
            userIn = Console.ReadLine();
            int upper = Int32.Parse(userIn);

            // a numbered loop, printing out the number in question on a new line.
            for ( int i = lower; i <= upper; i++)
            {
                // if (i % 5 == 0)
                // {
                //     Console.WriteLine("Buzz");
                // }

                if (i % 3 == 0 && i % 5 == 0 && i % 7 == 0) 
                {
                    Console.WriteLine("FizzBuzzBang");
                }
                else if (i % 3 == 0 && i % 5 == 0) 
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0 && i % 7 == 0) 
                {
                    Console.WriteLine("FizzBang");
                }
                else if (i % 5 == 0 && i % 7 == 0) 
                {
                    Console.WriteLine("BuzzBang");
                }
                else if (i % 3 == 0 )
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else if (i % 7 == 0)
                {
                    Console.WriteLine("Bang");
                }
                else
                {
                    Console.WriteLine(i);
                }

            }
        }
    }
}
