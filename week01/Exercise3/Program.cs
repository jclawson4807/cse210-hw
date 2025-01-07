using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the magic number? ");
        string magicNumberString = Console.ReadLine();

        Console.Write("What is your guess? ");
        string guessString = Console.ReadLine();

        int magicInt = int.Parse(magicNumberString);
        int guessInt = int.Parse(guessString);

        if (guessInt == magicInt)
        {
            Console.WriteLine("You guessed it!");
        }
        else if (guessInt > magicInt)
        {
            Console.WriteLine("Lower");
        }
        else
        {
            Console.WriteLine("Higher");     
        }
    }
}