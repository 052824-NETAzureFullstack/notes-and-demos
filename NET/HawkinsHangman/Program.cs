using System;
using System.Text.Json;
using System.IO;

namespace HawkinsHangman
{
    public record GameWord
    {
        public string gameWord { get; set; } = "";
        public string displayWord { get; set; } = "";
        public string hint { get; set; } = "";
    }

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
            GameWord word = NewWord();

            // Hide the letters in the word
            word = HideLetters(word);
            
            // Loop for display here
            do
            {
                Console.Clear();
                DisplayBoard(word, previousGuesses);
                // check if the puzzle is solved
                if (word.displayWord == word.gameWord)
                {
                    solved = true;
                    Console.WriteLine("Congratulations, you guessed the word!");
                }
                else
                {
                    // Prompt and accept a player guess
                    Console.Write("Please make a guess: ");

                    previousGuesses = GuessLetter(previousGuesses);

                    word.displayWord = CheckGuesses(word, previousGuesses);
                }
            } while (!solved);
        }

        public static GameWord NewWord()
        {
            string path = @"./words.json";
            string json = File.ReadAllText(path);
            List<GameWord> words = JsonSerializer.Deserialize<List<GameWord>>(json);
            Random rand = new Random();
            return words[rand.Next(words.Count)];
        }

        /// <summary>
        /// Hide the letters of a word, returning a string of '_' the same length as the word.
        /// </summary>
        /// <param name="gameWord">string</param>
        /// <returns name="hiddenWord">string</returns>
        public static GameWord HideLetters(GameWord word)
        {
            word.displayWord = "";
            foreach (char letter in word.gameWord)
            {
                word.displayWord += "_";
            }
            return word;
        }

        /// <summary>
        /// Accept and validate user letter guess
        /// </summary>
        /// <param name="previousGuesses"></param>
        /// <returns></returns>
        public static List<char> GuessLetter(List<char> previousGuesses)
        { 
            string? inputString = inputString = Console.ReadLine().ToUpper();

            if (String.IsNullOrEmpty(inputString))
            {
                Console.WriteLine("Invalid guess: you didn't enter anything.");
                Console.ReadLine();
            }
            else if (previousGuesses.Contains(inputString[0]))
            {
                Console.WriteLine("Invalid guess: you've already tried that one.");
                Console.ReadLine();
            }
            else
            {
                previousGuesses.Add(inputString[0]);
            }
        
            return previousGuesses;
        }

        public static void DisplayBoard(GameWord word, List<char> previousGuesses)
        {
            Console.WriteLine(word.hint + "\n");
            // Display the hidden word
            Console.Write(word.displayWord + "\t\t");

            // Display previously guessed letters
            foreach (char letter in previousGuesses)
            {
                Console.Write(letter + " ");
            }
            Console.WriteLine();
        }

        public static string CheckGuesses(GameWord word, List<char> previousGuesses)
        {                   
            Console.WriteLine(word.displayWord);
            char[] dW = word.displayWord.ToCharArray();

            foreach (char letter in previousGuesses)
            {
                for (int i = 0; i < word.gameWord.Length; i++)
                {
                    if (letter == word.gameWord[i])
                    {
                        dW[i] = letter;
                    }
                }
            }
            return new string(dW);
        }
    }
}