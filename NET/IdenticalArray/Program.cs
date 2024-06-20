/*
Given two string arrays word1 and word2, return true if the two arrays represent the same string, and false otherwise.

A string is represented by an array if the array elements concatenated in order forms the string.

Function Description
In the provided code snippet, implement the provided arrayStringsAreEqual(...) method using the variables to print the result that signifies whether the concatenated strings are equal or not. You can write your code in the space below the phrase “WRITE YOUR LOGIC HERE”. 

There will be multiple test cases running so the Input and Output should match exactly as provided.
The base output variable result is set to a default value of false which can be modified. Additionally, you can add or remove these output variables.

Input Format
The first line contains a String array word1
The second line contains a String array word2

Sample Input
"ab" "c"      -- denotes word1
"a" "bc"  -- denotes word2

Output Format
The output contains an integer value 1 or 0 denoting whether the concatenated arrays are equal or not

Sample Output
1

Explanation
 

word1 represents string "ab" + "c" -> "abc"
word2 represents string "a" + "bc" -> "abc"
The strings are the same, so return true and print the output 1.


*/
using System;

public class Test{
    static bool arrayStringsAreEqual(string[] word1, string[] word2) 
    {
        bool matching = true;
        //bool pending = word1.Length != word2.Length ? {return false} : true ; // dotnet isn't happy becuase the return is expression syntax.
        //Console.WriteLine(pending);
        if (word1.Length != word2.Length)
        {
            matching = false;
            return matching;
        }
        // int count = ((word1.Length > word2.Length) ? word2.Length : word1.Length);
        for (int y = 0; y < word1.Length; y++)
        {
            if (word1[y] != word2[y])
                matching = false;
        }
        return matching;
    }

   //DO NOT TOUCH THE CODE BELOW
    public static void Main()
    {
        string[] word1 = {"hello", "world"};
        string[] word2 = {"hello", "world"};
        bool result = arrayStringsAreEqual(word1, word2);
        Console.WriteLine(result);
    }
}