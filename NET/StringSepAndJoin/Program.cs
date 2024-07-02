using System;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        string test1 = "5433221";
        string answer1 = "1-2-3-4-5";
        
        // Test(test1);
        // Console.Write(Test(test1));
        Console.Write(Short(test1));
    }

    public static string Test(string X) // M
    {   
        if ((X.Length == 1))
            return X;
        
        char[] charArrayUnsorted = X.ToArray(); // M + M  
        Array.Sort(charArrayUnsorted);
        var sortedSet = new HashSet<char>(charArrayUnsorted); // M + M + M
        X = "";
        foreach (char s in sortedSet)
            X += s + "-";
        
        X = X.Remove(X.Length-1); // M + M + M 
    
        return X;
    }

    public static string Short(string X)
    {                               //12345 => "2"
        string[] chrs = X.Select(c => new string(c, 1)).ToArray();  // break the input string into a new array of strings
        Array.Sort(chrs);                                           // sort in place
        string[] uniq = chrs.Distinct().ToArray();                    // collect the distinct strings in the array chrs, and create a new array (.ToArray)
        return String.Join("-", uniq);                              // Join the array uniq together with "-" characters, and retun it.
    }

}