using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");

        Animation animation = new Animation();
        animation.DisplayRightLeftBarSpinnerForCountdownTimer(totalNumberOfSeconds: 30, progressiveSpinner: true);
    }
}