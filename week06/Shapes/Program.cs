using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square(color: "Blue", side: 2.7);
        Rectangle rectangle = new Rectangle(color: "Green", length: 2.7, width: 7.2);
        Circle circle = new Circle(color: "Green", radius: 2.7);

        Console.WriteLine($"Square {square.GetColor()} {square.GetArea()}");
        Console.WriteLine($"Rectangle {rectangle.GetColor()} {rectangle.GetArea()}");
        Console.WriteLine($"Circle {circle.GetColor()} {circle.GetArea()}");
    }
}