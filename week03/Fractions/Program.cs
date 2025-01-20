using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(5);
        Fraction fraction3 = new Fraction(3, 4);

        DisplayFractionValues(fraction1);
        DisplayFractionValues(fraction2);
        DisplayFractionValues(fraction3);

        fraction1.SetTop(1);
        fraction1.SetBottom(3);

        DisplayFractionValues(fraction1);
    }

    static void DisplayFractionValues(Fraction fraction)
    {
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine($"{fraction.GetDecimalValue()}");
    }
}