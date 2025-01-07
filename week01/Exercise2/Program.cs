using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gradePercentageString = Console.ReadLine();

        float gradePecentageFloat = float.Parse(gradePercentageString);

        string letterGrade = "E";

        if (gradePecentageFloat >= 90)
        {
            letterGrade = "A";
            Console.WriteLine($"Your grade is an {letterGrade}");
        }
        else if (gradePecentageFloat >= 80)
        {
            letterGrade = "B";
            Console.WriteLine($"Your grade is a {letterGrade}");
        }
        else if (gradePecentageFloat >= 70)
        {
            letterGrade = "C";
            Console.WriteLine($"Your grade is a {letterGrade}");
        }
        else if (gradePecentageFloat >= 60)
        {
            letterGrade = "D";
            Console.WriteLine($"Your grade is a {letterGrade}");
        }
        else
        {
            letterGrade = "F";
            Console.WriteLine($"Your grade is a {letterGrade}");    
        }
    }
}