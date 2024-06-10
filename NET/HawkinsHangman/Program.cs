using System;

namespace HawkinsHangman
{
    public class Program
    {
        /// <summary>
        /// Main method and game loop.
        /// </summary>
        public static void Main()
        {
            string playGame = "Y";
            
            while (playGame == "Y" || playGame == "YES")
            {
                NewGame();

                Console.WriteLine("Would you like to play a new game? [y/n]");
                playGame = Console.ReadLine().ToUpper();
            }
        }

        /// <summary>
        /// Game function and logic 
        /// </summary>
        public static void NewGame()
        {
            // Has the word been solved?
            bool solved = false;

            // List of previously guessed letters
            List<char> previousGuesses = [];

            // Select a new word for the game
            string gameWord = "POWERSHELL";

            // Hide the letters in the word
            string displayWord = HideLetters(gameWord);
            

            // Loop for display here
            do
            {
                // check if the puzzle is solved
                if (displayWord == gameWord)
                {
                    solved = true;
                }
                else
                {
                    Console.Clear();

                    DisplayBoard(displayWord, previousGuesses);

                    // Prompt and accept a player guess
                    Console.Write("Please make a guess: ");

                    previousGuesses = GuessLetter(previousGuesses);

                    displayWord = CheckGuesses(gameWord, displayWord, previousGuesses);
                }
            } while (!solved);
        }

        /// <summary>
        /// Hide the letters of a word, returning a string of '_' the same length as the word.
        /// </summary>
        /// <param name="gameWord">string</param>
        /// <returns name="hiddenWord">string</returns>
        public static string HideLetters(string gameWord)
        {
            string hiddenWord = "";
            foreach (char letter in gameWord)
            {
                hiddenWord += "_";
            }
            return hiddenWord;
        }

        /// <summary>
        /// Accept and validate user letter guess
        /// </summary>
        /// <param name="previousGuesses"></param>
        /// <returns></returns>
        public static List<char> GuessLetter(List<char> previousGuesses)
        {
            
            char guess = Console.ReadLine().ToUpper()[0];

            // Needs Validation!

            // Add the current guess to the previously guessed letters
            previousGuesses.Add(guess);

            return previousGuesses;
        }

        public static void DisplayBoard(string displayWord, List<char> previousGuesses)
        {
            // Display the hidden word
            Console.Write(displayWord + "\t\t");

            // Display previously guessed letters
            foreach (char letter in previousGuesses)
            {
                Console.Write(letter + " ");
            }
            Console.WriteLine();
        }

        public static string CheckGuesses(string gameWord, string displayWord, List<char> previousGuesses)
        {                   
            Console.WriteLine(displayWord);
            char[] dW = displayWord.ToCharArray();

            foreach(char letter in previousGuesses)
            {
                if (gameWord.Contains(letter))
                {
                    int index = gameWord.IndexOf(letter);
                    dW[index] = letter;
                }
            }
            return new string(dW);
        }
    }
}