public class Program
{
    public static void Main(string[] args)
    {
        // inline comments are created with the "//"
        /* or block comments can start and end with  the "/*" and */

        // console refers to the terminal console, or the console window that .NET will create.
        // we have .ReadLine and .WriteLine methods

        Console.WriteLine("Please enter your name: ");

        // when creating a variable, declare the type/collection!
        string name;
        name = Console.ReadLine();

        // we can leverage concatenation to "add" strings together on the fly (works with string variables too!)
        Console.WriteLine("Hello, " + name + "!");
        
        // tell the code to run the CoinFlip method
        CoinFlip();

        return;
    }

    public static void CoinFlip()
    {
        Console.WriteLine("CoinFlip starting...");

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

        // we could swap the coin variable type to a string
        // we could add another string variable to add "heads" or "tails"
        // we could have a collection and use the coin value as a key to "heads" and "tails" values - Collections/ Dictionary
        // we could use an inline ternary statemnt to select the right side of the coin based on the the bool

        Console.WriteLine("The coin was flipped, and landed on: " + ((coin) ? "tails" : "heads") );
    }
}