using System;

namespace FizzBuzz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Program Variables - modify these to change the associated words! (Don't touch anything else, or ELSE!)
            int fizzVal = 3;
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
                string output = "";

                if (i % fizzVal == 0 )
                {
                    output = output + "Fizz";
                }

                if (i % buzzVal == 0)
                {
                    output = output + "Buzz";
                }
                
                if (i % bangVal == 0)
                {
                    output = output + "Bang";
                }

                if (String.IsNullOrEmpty(output))
                {
                    output = output + i.ToString();
                }

                Console.WriteLine(output);                
            }
        }
    }
}
