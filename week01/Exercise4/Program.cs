using System;

class Program
{

    /*
    For this assignment, write a C# program that has several simple functions:

    
    
    
    
    
    Your Main function should then call each of these functions saving the return values and passing data to them as necessary.
    */

    // DisplayWelcome - Displays the message, "Welcome to the Program!"
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // PromptUserName - Asks for and returns the user's name (as a string)
    static string PromptUserName()
    {
        Console.WriteLine("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    // PromptUserNumber - Asks for and returns the user's favorite number (as an integer)
    static int PromptUserNumber()
    {
        Console.WriteLine("Please enter your favorite number: ");
        string favoriteNumberString = Console.ReadLine();

        try
        {
            int favoriteNumberInt = int.Parse(favoriteNumberString);
            return favoriteNumberInt;
        }
        catch (Exception e)
        {
            Console.WriteLine("You must enter an integer value.");
            throw;
        }
    }

    // SquareNumber - Accepts an integer as a parameter and returns that number squared (as an integer)
    static int SquareNumber(int valueToSquare)
    {
        int squaredValue = valueToSquare * valueToSquare;
        return squaredValue;
    }

    // DisplayResult - Accepts the user's name and the squared number and displays them.
    static void DisplayResult(string usersName, int squaredValue)
    {
        Console.WriteLine($"{usersName}, the square of your number is {squaredValue}");
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");
    }
}