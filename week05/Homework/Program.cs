using System;

class Program
{
    static void Main(string[] args)
    {
        // test step 3
        Assignment assignment1 = new Assignment("Samuel Bennett", "Multiplication");

        Console.WriteLine(assignment1.GetSummary());
        Console.WriteLine("");
        // test step 4
        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());
        Console.WriteLine("");

        // test step 5
        WritingAssignment writingAssignment = new WritingAssignment("Mary Watters", "European History", "The Causes of World War II");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}