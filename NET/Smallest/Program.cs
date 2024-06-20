/*You are given an array having N elements and an integer K.

You have to write a program to find the smallest number greater than K which is not present in the given array.

Example
If the array is A = [ 2, 5, 7, 9, 21, 34] and K = 20
The output will be 22.
22 will be the smallest number greater than K=20 which is not present in the given array.

Function Description
In the provided code snippet, implement the provided notInArray(...) method using the variables to print the smallest number greater than K which is not present in the given array. You can write your code in the space below the phrase “WRITE YOUR LOGIC HERE”. 

There will be multiple test cases running so the Input and Output should match exactly as provided.
The base Output variable result is set to a default value of -404 which can be modified. Additionally, you can add or remove these output variables.

Input Format
The code provided handles the input and stores them in variables for you.
The first line contains an integer N denoting the size of the array.
The next N lines contain elements of array A.
The next line contains an integer, K.

Sample Input
5        -- denotes N
1        -- denotes elements of Array N
4
5
2
7
4        -- denotes K
Constraints
1 <= N <= 105
1 <= A[i] <= 105
1 <= K <= 105

Output Format
The output contains an integer denoting the smallest number greater than K which is not present in the given array.

Sample Output
6
Explanation
The array is [1,4,5,2,7] and K=4
The smallest element which is greater than K = 4 and not present in the array is 6.
Hence the output is 6.
Skill:Foundation
Program
*/

//Sort the array
//Iterate through our arrray
//Compare a value to our values

using System;
using System.Collections.Generic;
using System.Linq;

public class Test{

    //The array is [1,4,5,2,7] and K=4
    static int notInArray(int N, int[] A, int K)
    {
        /*
            foreach (int i in A)
            Console.Write(i + ", ");
        Console.WriteLine();

        // LINQ - Language Integrated Queries
        IEnumerable<int> B = 
            from val in A
            where val > K
            select val;

        foreach (int i in B)
            Console.Write(i + ", ");
        Console.WriteLine();
        */

        int newNum = K + 1;
        Array.Sort(A);

        if (newNum > A[N-1])
        {
            return newNum;
        }

        for (int x = 0; x < N; x++)
        {
            if (newNum > A[x])
            {
                continue;
            }
            else if (newNum == A[x])
            {
                newNum++;
            }
            else
                break;
        }
        return newNum;
    }

/*        
        while(solution == false)
        {
            if (newNum > A[N-1])
                return newNum;

            for (int i = 0; i < N; i++)
            {
                if (A[i] < newNum)
                {
                    Console.WriteLine("{0} is less than {1}", A[i], newNum);
                    continue;
                }
                else if (A[i] == newNum)
                {
                    newNum++;
                    break;
                }
                else
                {
                    solution = true;
                    return newNum;
                }
            }
        }
        return newNum;
    */
    

    //DO NOT TOUCH THE CODE BELOW
    public static void Main()
    {
        int N = 7;
        int[] A = {1, 2, 3, 4, 5, 6, 7};
        int K = 4;
        int result = notInArray(N, A, K);
        Console.WriteLine((result));
    }
}