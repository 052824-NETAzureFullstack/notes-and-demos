/*
13. Write a C# program that takes a number as input and displays a rectangle of 3 columns wide and 5 rows tall using that digit.

Test Data:
Enter a number: 5
Expected Output:
555
5 5
5 5
5 5
555

*/


//The strategy:
//Readline to gather input?
//A loop to display the input as a rectangle?
//Convert our int input into a string

using System;

namespace RectangleChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = "";
            string caps = "";
            string body = "";
            int cols = 7;
            int rows = 8;

            Console.Write("Enter your number here: ");
            input = Console.ReadLine(); //We need to later do some validation

            // build caps and body
            for (int x = 0; x < cols; x++)
            {
                //build caps
                caps += input;

                //build body
                if (x == 0 || x == cols-1)
                {
                    body += input;
                } 
                else 
                {
                    body += " ";
                }
            }

            Console.WriteLine();

            // Row output
            for (int i = 0; i < rows; i++)
            {
                if (i == 0 || i == rows-1)
                {
                    Console.WriteLine(caps);
                }
                else
                {
                    Console.WriteLine(body);
                }
            }


            /*

            if (i == 0 || i == rows-1)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write(input);
                    }
                }
                else
                {
                    // Column output
                    for (int j = 0; j < cols; j++)
                    {  
                        if (j == 0 || j == cols-1)
                        {
                            Console.Write(input);
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
                Console.WriteLine();
            }
                    5555 - row
                    5  5
                    5  5
                    5  5
                    5555
                    |
                    column
                

            */
            
            // while (input > 0) {
            //     Console.WriteLine(input);
            //     i--;
            // }
        }
    }
}
