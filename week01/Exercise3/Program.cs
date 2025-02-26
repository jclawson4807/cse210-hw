using System;

class Program
{
    static void Main(string[] args)
    {
        /*
        1. Start by asking the user for the magic number. (In future steps, we will change this to have the 
        computer generate a random number, but to get started, we'll just let the user decide what it is.)
        Ask the user for a guess.
        Using an if statement, determine if the user needs to guess higher or lower next time, or tell them if they guessed it.
        At this point, you won't have any loops.

        2. Add a loop that keeps looping as long as the guess does not match the magic number.
        At this point, the user should be able to keep playing until they get the correct answer.

        3. nstead of having the user supply the magic number, generate a random number from 1 to 100.
        Play the game and make sure it works!

        Stretch Challenge

        1. Keep track of how many guesses the user has made and inform them of it at the end of the game.
        2. After the game is over, ask the user if they want to play again. Then, loop back and play the 
        whole game again and continue this loop as long as they keep saying "yes".
        */
        
        Random randomGenerator = new Random();
        int magicInt = randomGenerator.Next(1, 101); // is this supposed to be 1 to 100 inclusive or exclusive?

        int numberOfGuesses = 0;
        string pluralityString = "s";

        bool doContinue = true;

        while (doContinue)
        {
            Console.Write("What is your guess? ");
            string guessString = Console.ReadLine();

            numberOfGuesses += 1;

            int guessInt = 0;

            try
            {
                guessInt = int.Parse(guessString);
            }
            catch (Exception e)
            {
                Console.WriteLine("You must enter an integer value.");
                break;
            }

            if (guessInt == magicInt)
            {
                if (numberOfGuesses == 1)
                {
                    pluralityString = "";
                }

                Console.WriteLine($"You guessed it!  It took you {numberOfGuesses} turn{pluralityString}. ");

                Console.Write("Do you want to play again? (yes or no) ");
                string playAgainResponseString = Console.ReadLine().ToUpper();

                if (playAgainResponseString != "YES")
                {
                    doContinue = false;
                }
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