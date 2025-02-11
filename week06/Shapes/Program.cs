using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square(color: "blue", side: 2.7);

        Console.WriteLine($"{square.GetColor()} {square.GetArea()}");
    }
}