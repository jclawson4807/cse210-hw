using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square(color: "Blue", side: 2.7);
        Rectangle rectangle = new Rectangle(color: "Green", length: 2.7, width: 7.2);
        Circle circle = new Circle(color: "Green", radius: 2.7);

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetColor()} {shape.GetArea()}");
        }
    }
}