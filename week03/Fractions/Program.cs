using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.");

        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(52);
        Fraction fraction3 = new Fraction(22, 3);

        DisplayFractionValues(fraction1);
        DisplayFractionValues(fraction2);
        DisplayFractionValues(fraction3);

        fraction1.SetTop(2);
        fraction1.SetBottom(3);

        DisplayFractionValues(fraction1);
    }

    static void DisplayFractionValues(Fraction fraction)
    {
        Console.WriteLine($"top: {fraction.GetTop()} bottom: {fraction.GetBottom()}");
    }
}