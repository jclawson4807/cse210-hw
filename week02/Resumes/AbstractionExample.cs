using System;
using System.Data;

public class AbstractionExample
{
    int maxNumber;
    int firstTerm = 0;
    int secondTerm = 1;
    List<int> fibonacciValues = new List<int>();

    public void Reset()
    {
        fibonacciValues.Clear();

        fibonacciValues.Add(firstTerm);
        fibonacciValues.Add(secondTerm);
    }

    public void Calculate(int maxNumberArg)
    {
        Reset();

        maxNumber = maxNumberArg;

        int calculated_value = 0;

        while (calculated_value < maxNumber)
        {
            calculated_value = firstTerm + secondTerm;
            fibonacciValues.Add(calculated_value);

            firstTerm = secondTerm;
            secondTerm = calculated_value;
        }
    }

    public void DisplayFibonacciSequence()
    {
        Console.WriteLine($"Fibonacci sequence with upper bound {maxNumber}");
        Console.WriteLine("");

        foreach (int value in fibonacciValues)
        {
            Console.WriteLine(value);
        }
    }

    public List<int> GetFibonacciValueList()
    {
        return fibonacciValues;
    }
}