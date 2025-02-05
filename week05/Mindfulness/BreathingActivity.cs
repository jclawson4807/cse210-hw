using System;

public class BreathingActivity: Activity
{
    private int _breatheInDuration = 4;
    private int _breatheOutDuration = 6;

    public BreathingActivity()
    {
        SetActivityName("Breathing Activity");
        SetWelcomeMessage("Welcome to the Breathing Activity.");
        SetActivityDescriptionMessage("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        SetHowLongMessage("How long, in sections, would you like for your session?");
        SetAfterActivityMessage("You have completed another ", " seconds of the Breathing Activity.  Good job!");
    }

    public void SetBreatheDuration(int breatheInDuration, int breatheOutDuration)
    {
        _breatheInDuration = breatheInDuration;
        _breatheOutDuration = breatheOutDuration;
    }

    public void MindfulnessActivity()
    {
        Console.WriteLine("");
        Console.WriteLine("");

        Animation animation = GetAnimation();
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetActivityDurationInSeconds());

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            animation.DisplayCountdownTimer(_breatheInDuration);
            Console.WriteLine("");
            
            Console.Write("Now breathe out...");
            animation.DisplayCountdownTimer(_breatheOutDuration);
            Console.WriteLine("\n\n");
        }

        Console.WriteLine("Well done!!");
        animation.DisplayDefaultSpinnerForCountdownTimer(4, false);
        Console.WriteLine("\n\n");

        Console.WriteLine(GetAfterActivityMessage());

        Thread.Sleep(2000);

        DisplayStartMenu();
    }
}