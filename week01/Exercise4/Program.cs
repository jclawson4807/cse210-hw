using System;
using System.Collections.Generic;

class Program
{
    // Ask the user for a series of numbers, and append each one to a list. Stop when they enter 0. (Remember: You should not add 0 to the list. If you do, later calculations and operations will not be correct.)

    // Once you have a list, have your program do the following:

    // Core Requirements

    // Work through these core requirements step-by-step to complete the program. Please don't skip ahead and do the whole thing at once, because others on your team may benefit from building the program up slowly.

    // Compute the sum, or total, of the numbers in the list.
    // Compute the average of the numbers in the list.
    // Find the maximum, or largest, number in the list.

    static void Main(string[] args)
    {
        List<int> userNumbers = new List<int>();

        bool doContinue = true;

        Console.WriteLine("Enter a list of numbers, type 0 when finished");

        int largestNumber = 0;
        int smallestNumber = 0;
        float sumOfNumbers = 0;

        while (doContinue)
        {
            Console.Write("Enter number: ");
            string userNumberString = Console.ReadLine();

            try
            {
                int userNumberInt = int.Parse(userNumberString);

                if (userNumberInt == 0)
                {
                    doContinue = false;     
                }
                else
                {
                    userNumbers.Add(userNumberInt);

                    sumOfNumbers += userNumberInt;

                    if (userNumberInt > largestNumber)
                    {
                        largestNumber = userNumberInt;
                    }
                    else if (userNumberInt > 0 && (smallestNumber == 0 || (userNumberInt < smallestNumber)))
                    {
                        // Have the user enter both positive and negative numbers, then find the smallest positive number (the positive number that is closest to zero).
                        smallestNumber = userNumberInt;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("You must enter an integer value.");
            }
        }

        int listCount = userNumbers.Count;
        float averageNumber = sumOfNumbers / (float)listCount;

        Console.WriteLine($"The sum is: {sumOfNumbers}");
        Console.WriteLine($"The average is: {averageNumber}");
        Console.WriteLine($"The largest number is: {largestNumber}");
        Console.WriteLine($"The smallest positive number is: {smallestNumber}");


        // Sort the numbers in the list and display the new, sorted list
        userNumbers.Sort();

        Console.WriteLine("The sorted list is:");

        foreach (int number in userNumbers)
        {
            Console.WriteLine(number);
        }
    }
}