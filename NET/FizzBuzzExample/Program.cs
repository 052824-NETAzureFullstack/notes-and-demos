﻿using System;

namespace FizzBuzz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Program Variables - modify these to change the associated words! (Don't touch anything else, or ELSE!)
            int fizzVal = 4;
            int buzzVal = 5;
            int bangVal = 7;
         
         
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

                if (i % fizzVal == 0 && i % buzzVal == 0 && i % bangVal == 0) 
                {
                    Console.WriteLine("FizzBuzzBang");
                }
                else if (i % fizzVal == 0 && i % buzzVal == 0) 
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % fizzVal == 0 && i % bangVal == 0) 
                {
                    Console.WriteLine("FizzBang");
                }
                else if (i % buzzVal == 0 && i % bangVal == 0) 
                {
                    Console.WriteLine("BuzzBang");
                }
                else if (i % fizzVal == 0 )
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % buzzVal == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else if (i % bangVal == 0)
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
