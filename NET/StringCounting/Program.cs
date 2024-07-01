using System;
using System.Collections.Generic;
using System.Linq;

public class Test{

    public static int checkForALetter(List<string> stringList, string letter)
    {   //WRITE YOUR CODE HERE
        int count = 0; // how many words in the list, contain the letter?
        char search = letter[0];
        
        foreach(string check in stringList) // for each word in stringList, call each one "check" and look at it.
        {
            if(check.Contains(search)) //does the word "check" contain a matching character "letter"
                count++;    
        }
        return count;
    }

    //DO NOT TOUCH THE CODE BELOW
    public static void Main()
    {
        string letter = "p";
        List<string> stringList = new List<string>{"quick", "rousing", "snappy", "sparkling", "sprightly", "spry", "stirring", "vivacious", "zippy"};

        Console.WriteLine(checkForALetter(stringList, letter));
    }
}