public class Program
{
    public static void Main(string[] args)
    {
        // // inline comments are created with the "//"
        /* or block comments can start and end with  the "/*" and */

        // // console refers to the terminal console, or the console window that .NET will create.
        // // we have .ReadLine and .WriteLine methods

        // Console.WriteLine("Please enter your name: ");

        // // when creating a variable, declare the type/collection!
        // string name;
        // name = Console.ReadLine();

        // // we can leverage concatenation to "add" strings together on the fly (works with string variables too!)
        // Console.WriteLine("Hello, " + name + "!");
        
        // tell the code to run the CoinFlip method

        // while loop - let us keep repeating until the condition is false
        // do while - do the action, then check the condition. loop if true
        // for loop - defined starting, conditon, and step values
        // foreach - enhanced for loop - iterates through an IEnumerable

        bool cont = false;
        do
        {
           cont = CoinFlip();
           Console.Clear();
        } while(cont);
        
        Console.WriteLine("Thanks for playing!");

        return;
    }

    public static bool CoinFlip()
    {
        // True == Tails (keep the t's together!)

        Console.WriteLine("CoinFlip starting...");
        bool coin = NewCoin();
        bool user = PlayerGuess();


       
        // we could swap the coin variable type to a string
        // we could add another string variable to add "heads" or "tails"
        // we could have a collection and use the coin value as a key to "heads" and "tails" values - Collections/ Dictionary
        // we could use an inline ternary statemnt to select the right side of the coin based on the the bool

        Console.WriteLine("The coin was flipped, and landed on: " + ((coin) ? "tails" : "heads") );
        Console.WriteLine("You chose: " + ((coin) ? "tails" : "heads") );
        Console.WriteLine((coin == user) ? "Congratulations, you guessed correctly!" : "Sorry, you guessed wrong!");


        Console.WriteLine("Play again? [y/n]");
        string playAgain = Console.ReadLine();

        return (playAgain == "y" || playAgain == "Y" || playAgain == "yes" || playAgain == "yup");
    }

    public static bool NewCoin()
    {
         // boolean variables are noted with "bool"
        bool coin; 

        // we can use a pseudo-random number generator to "flip" our coin
        Random rand = new Random(); // woohoo! our first class object in C#!!!
        int value = rand.Next(); // pull the next random number from our generator

        int remainder = value % 2; // the "%" is our modulous operator, that provides the remainder of a division operation.

        if ( remainder == 0)
        {
            coin = false;
        }
        else 
        {
            coin = true;
        }

        return coin;
    }

/// <summary>
/// Accept the players guess of heads or tails
/// </summary>
/// <returns>bool guess</returns>
    public static bool PlayerGuess()
    {
        // prompt the player to select heads or tails, and return true or false
        // accept a string for "heads" or "tails"
        // accept a numerical representation (1 or 0)
        int userChoice = -1;

        do
        {
            try
            {
                Console.WriteLine("Please select Heads or Tails:");
                Console.WriteLine("[0] - Heads");
                Console.WriteLine("[1] - Tails");

                // With Console.ReadLine, everyting that is entered is a string. we need to convert if we want something else.
                //string userInput = Console.ReadLine();

                userChoice = Int32.Parse(Console.ReadLine());
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine("You must enter a number to continue.");
            }
            catch(FormatException)
            {
                Console.WriteLine("input must me an integer");
            }
            catch(OverflowException)
            {
                Console.WriteLine("Now that was just rediculous.");
            }
            catch(Exception)
            {
                Console.WriteLine("Unexpected Input, Please try again: ");
            }
            finally
            {
                Console.WriteLine("Continuing on...");
            }

        } while (userChoice != 1 || userChoice != 0);
       
       /*
        if (userChoice == 1 || userChoice == 0) // only a 1 or a 0 will enter the if statement
        {
            return (userChoice == 1)? true : false;
        }
        else
        {
            Console.WriteLine("Improper input detected");
        }

        return false;
        */

        return (userChoice == 1)? true : false;
    }
}