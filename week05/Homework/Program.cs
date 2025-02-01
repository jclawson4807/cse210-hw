using System;

class Program
{
    static void Main(string[] args)
    {
        // test step 3.5 - 
        Assignment assignment1 = new Assignment("Samuel Bennett", "Multiplication");

        Console.WriteLine(assignment1.GetSummary());

        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
    }
}