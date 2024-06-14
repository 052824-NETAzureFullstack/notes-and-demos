/*
You are tasked to convert a string of letters into a secret code. Your job is to take a string of letters (ignoring case) and convert it into a secret code using the following rules:

A = 01, B = 02, C = 03, D = 04, ..., Z = 26
(the code is follows the alphabet numerically with the number representing what number of the alphabet the letter is)

The createSecretCode() method takes in 1 argument:
s - the string that will be converted into the secret code string
Once you've created the secret code version of the string, return the secret code string.
 
 
Example Input:	Example Output:
AbCygHg	01020325070807
Explanation:
Following the pattern (and ignoring upper and lower case), the letters are converted as followed:
A=01
b=02
C=03
y=25
g=07
H=08
g=07
*/

using System;
public class Test{

    public static string createSecretCode(string s)
    {
        Dictionary<char,int> secretDict = new Dictionary<char,int>();
        string secret = s.ToLower();
        int num = 97;
        string result = "";
        string x = "";
        
        //Looping to fill the dictionary
        for(int i = 0; i < 26; i++)
        {
            secretDict.Add((char)num, i+1);
            num++;
        }

        // lookup the value associated with the letter (key), build an output string of the numbers
        foreach (char letter in secret) // iterate thorugh the string, examinine each letter of the string
        {
            // compare the letter in the string to the key in the dictionary, and return the value from the dictionary
            x = secretDict[letter].ToString().PadLeft(2,'0');
            result += x;         
        }

        Console.WriteLine(result);
        
        // string PadLeft( int totalWidth, char paddingChar)
        // polymorphism - having many forms - a method with one name that can accept many different variations of parameters
        //  - OR - for every different form (set of parameters) we can have modified behaviors

        // PadLeft(2) - filled the rest of the padding space with space characters
        // PadLeft(2, '0') - filled the rest of the padding space with '0' characters


        // Console.WriteLine("Pad  2 :'{0}'", x); 
        
        // // Looping to write to terminal
        // foreach (KeyValuePair<char, int> l in secretDict)
        // {
        //     Console.WriteLine("{0} - {1}", l.Key, l.Value);
        // }

        // we need to deal with the casing on our own!
        // options
        // to our machine, A and a are not Equal
        // Dictionary! character is the key, int is the value
        return result;
    }

    public static void Main()
    {
        string s = "AbCygHg";
        string conv = "01020325070807";
        Console.WriteLine(conv.Equals(createSecretCode(s)));
    }
}