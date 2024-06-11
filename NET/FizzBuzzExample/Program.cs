using System;

namespace FizzBuzz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Program Variables - modify these to change the associated words! (Don't touch anything else, or ELSE!)
            // Dictionary - (hashmap) uses key/value pairs
            // int fizzVal = 3;// "fizz"
            // int buzzVal = 5;// "buzz"
            // int bangVal = 7;// "bang"
            // int crackVal = 9;// "crack"

            Dictionary<int, string> wordVals = new Dictionary<int, string>();
            wordVals.Add(3, "Fizz");
            wordVals.Add(5, "Buzz");
            wordVals.Add(7, "Bang");
            wordVals.Add(9, "Crack");
         
         
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
                Console.WriteLine(FizzBuzzBuilder(i, wordVals));                
            }
        }

        public static string FizzBuzzBuilder(int i, Dictionary<int, string> wordVals)
        {
            string output = "";
            
            foreach(KeyValuePair<int, string> val in wordVals)
            {
                if (i % val.Key == 0 )
                {
                    output += val.Value;
                }
            }

            if (String.IsNullOrEmpty(output))
            {
                output += i.ToString();
            }

            return output;
        }
    }
}
