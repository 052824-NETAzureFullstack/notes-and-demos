using System; 
using System.Collections.Generic;
using System.Linq;

public class Test{

    public static List<string> quick_alphabetize(List<string> stringList)
    {
        stringList.Sort();
        return stringList;
    }

    public static List<string> sorting_fun(List<string> stringList)
    {

        List<string> result = new List<string>();
        result.Add(stringList[0]);

        //stringList.Insert(pos, object;)

        
        for (int i = 1; i < stringList.Count; i++)
        {
            Console.WriteLine("In for {0}", i);
            int k = 0;
            while (stringList[i][0] > result[k][0])
            {
                Console.WriteLine("In while {0}", k);
                k++;
                if (k == i+1)
                {
                    result.Insert(k, stringList[i+1]);
                    break;
                }
            }
            result.Insert(k, stringList[i]);
            
            foreach( string w in result)
            {
                Console.Write(" {0},", w);
            }
            Console.WriteLine();
        }
        return result;
    }




/*

if (i < (stringList.Count - 1))
                {
                    if (stringList[i][j] > stringList[i+1][j])
                    {
                        result.Add(stringList[i+1]);
                        Console.Write("word: {0}   letter: {1}  ", i, j);
                        foreach( string w in result)
                        {
                            Console.Write(" {0},", w);
                        }
                        Console.WriteLine();
                        break;
                    }
                    
                    else if (stringList[i][j] < stringList[i+1][j])
                    {
                        result.Add(stringList[i]);
                        Console.Write("word: {0}   letter: {1}  ", i, j);
                        foreach( string w in result)
                        {
                            Console.Write(" {0},", w);
                        }
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                        
            // {
            //     if (stringList[i][j] > result[i+1][j])
            //     {
            //         stringList.Insert(result.Count, stringList[i]);
            //     }
            //     else if (stringList[i][j] < result[i][j])
            //     {
            //         stringList.Insert(0,stringList[i]);
            //     }
                
                // Console.Write("word: {0}   letter: {1}  ", i, j);
                // foreach( string w in result)
                // {
                //     Console.Write(" {0},", w);
                // }
                */

    //DO NOT TOUCH THE CODE BELOW
    public static void Main()
    {
        List<string> stringList = new List<string>{"This", "Is", "A", "List", "Of", "Words"};
        //List<string> sortedList = quick_alphabetize(stringList);
        List<string> sortedList = sorting_fun(stringList);
        
        foreach(string word in sortedList)
        {
            Console.WriteLine(word);
        }
    }
}