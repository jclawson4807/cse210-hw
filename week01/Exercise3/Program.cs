using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicInt = randomGenerator.Next(1, 15);

        bool doContinue = true;

        while (doContinue)
        {
            Console.Write("What is your guess? ");
            string guessString = Console.ReadLine();

            int guessInt = int.Parse(guessString);

            if (guessInt == magicInt)
            {
                Console.WriteLine("You guessed it!");
                doContinue = false;
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
}