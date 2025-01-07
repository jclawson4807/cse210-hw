using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        /*
        Ask the user for their grade percentage, then write a series of if, else if, else statements to print out
        the appropriate letter grade. (At this point, you'll have a separate print statement for each grade letter 
        in the appropriate block.)

        Assume that you must have at least a 70 to pass the class. After determining the letter grade and printing it 
        out. Add a separate if statement to determine if the user passed the course, and if so display a message to 
        congratulate them. If not, display a different message to encourage them for next time.

        Change your code from the first part, so that instead of printing the letter grade in the body of each if, else 
        if, or else block, instead create a new variable called letter and then in each block, set this variable to the 
        appropriate value. Finally, after the whole series of if, else if, else statements, have a single print statement 
        that prints the letter grade once.
        */
        
        Console.Write("What is your grade percentage? ");
        string gradePercentageString = Console.ReadLine();

        float gradePecentageFloat = float.Parse(gradePercentageString);

        string letter = "E";
        bool didPass = false;

        if (gradePecentageFloat >= 90)
        {
            letter = "A";
            didPass = true;
        }
        else if (gradePecentageFloat >= 80)
        {
            letter = "B";
            didPass = true;
        }
        else if (gradePecentageFloat >= 70)
        {
            letter = "C";
            didPass = true;
        }
        else if (gradePecentageFloat >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";   
        }

        if (letter == "A")
        {
            Console.WriteLine($"Your grade is an {letter}");
        }
        else
        {
            Console.WriteLine($"Your grade is a {letter}");
        }

        if (didPass)
        {
            Console.WriteLine("Contraulations!  You passed the class!");    
        }
        else
        {
            Console.WriteLine("You did not pass the class.  Try harder next time!");    
        }
    }
}