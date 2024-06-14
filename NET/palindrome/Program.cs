/*
You are given a single string, and it is your job to figure out if that string is a palindrome. A palindrome is a number or word that are the same forwards and backwards (with exact upper/lower casing).

The checkForPalindrome() method takes in 1 argument:
s - the string that you are checking to see if it's a palindrome
Once you've determined whether or not the string is a palindrome, return either true or false.
 
 
Example Input:	Example Output:
abbabba	true
Explanation:
abbabba backwards is abbabba, therefore the string is a palindrome and the method returns true.
*/

using System;
public class Test{

    public static bool checkForPalindrome(string s)
    {
        // no casing to worry about, it's handled in the main method!
        // options:
            // split the string into substrings, (one is reversed), and compare the strings. If they're equal, it's a palindrome.
            // loop through the string backwords, building a reversed version of the string. Compare to the original string.
            // revese method to generate a reversed string, and compare.

        string reversed = "";
        for (int i = s.Length-1; i >= 0; i--)
        {
            reversed += s[i];
        }
        
        // return (s == reversed) ? true : false;
        // OR
        // if (s == reversed)
        // {
        //     return true;
        // }
        // else
        // {
        //     return false;
        // }
        // OR
        return s.Equals(reversed);
    }

    public static void Main()
    {
        string s = "abbabba";
        Console.WriteLine(checkForPalindrome(s).ToString().ToLower());
    }
}