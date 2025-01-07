using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        /*
        1. Ask the user for their grade percentage, then write a series of if, else if, else statements to print out
        the appropriate letter grade. (At this point, you'll have a separate print statement for each grade letter 
        in the appropriate block.)

        2. Assume that you must have at least a 70 to pass the class. After determining the letter grade and printing it 
        out. Add a separate if statement to determine if the user passed the course, and if so display a message to 
        congratulate them. If not, display a different message to encourage them for next time.

        3. Change your code from the first part, so that instead of printing the letter grade in the body of each if, else 
        if, or else block, instead create a new variable called letter and then in each block, set this variable to the 
        appropriate value. Finally, after the whole series of if, else if, else statements, have a single print statement 
        that prints the letter grade once.

        Stretch Challenge
        1. Add to your code the ability to include a "+" or "-" next to the letter grade, such as B+ or A-. For each grade, 
        you'll know it is a "+" if the last digit is >= 7. You'll know it is a minus if the last digit is < 3 and otherwise 
        it has no sign.

        After your logic to determine the grade letter, add another section to determine the sign. Save this sign into a 
        variable. Then, display both the grade letter and the sign in one print statement.

        Hint: To get the last digit, you could divide the number by 10, and get the remainder. You might review the standard 
        math operators and find the one that does division and gives you the remainder.

        At this point, don't worry about the exceptional cases of A+, F+, or F-.

        2. Recognize that there is no A+ grade, only A and A-. Add some additional logic to your program to detect this case and 
        handle it correctly.

        3. Similarly, recognize that there is no F+ or F- grades, only F. Add additional logic to your program to detect these 
        cases and handle them correctly.
        */
        
        Console.Write("What is your grade percentage? ");
        string gradePercentageString = Console.ReadLine();

        float gradePecentageFloat = float.Parse(gradePercentageString);

        string letter = "E";
        bool didPass = false;
        string gradeSign = "";

        float gradeRemainder = gradePecentageFloat % 10;

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

        if (gradeRemainder >= 7 && gradePecentageFloat < 90 && gradePecentageFloat > 60)
        {
            gradeSign = "+";    
        }
        else if (gradeRemainder < 3 && gradePecentageFloat < 93 && gradePecentageFloat > 60)
        {
            gradeSign = "-";     
        }

        if (letter == "A")
        {
            Console.WriteLine($"Your grade is an {letter}{gradeSign}");
        }
        else
        {
            Console.WriteLine($"Your grade is a {letter}{gradeSign}");
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