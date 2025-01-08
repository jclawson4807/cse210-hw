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
                else{
                    userNumbers.Add(userNumberInt);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("You must enter an integer value.");
            }
        }

        
    }
}