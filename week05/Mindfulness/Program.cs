using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");

        Animation animation = new Animation();
        // animation.DisplayCountdownTimer(totalNumberOfSeconds: 11);
        // animation.DisplayProgressiveCountdownTimer(totalNumberOfSeconds: 30);
        animation.DisplayArrowSpinnerForCountdownTimer(totalNumberOfSeconds: 30, progressiveSpinner: true);
    }
}