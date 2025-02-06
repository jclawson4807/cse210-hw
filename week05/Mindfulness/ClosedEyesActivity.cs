using System;

public class ClosedEyesActivity: Activity
{
    private List<string> _responses = new List<string>();

    public ClosedEyesActivity()
    {
        SetActivityName("Clear Your Mind Relaxation Activity");
        SetWelcomeMessage("Welcome to the Clear Your Mind Relaxation Activity.");
        SetActivityDescriptionMessage("This activity will help you try to clear your mind.  You will close your eyes and try to still your thoughts.");
        SetHowLongMessage("How long, in sections, would you like for your session?");
        SetAfterActivityMessage("You have completed another ", " seconds of the Clear Your Mind Activity.  Good job!");
    }

    public void MindfulnessActivity()
    {
        Console.Clear();
        _responses.Clear();

        Console.WriteLine("");
        Console.WriteLine("");

        Animation animation = GetAnimation();
        Random random = GetRandom();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetActivityDurationInSeconds());

        Console.WriteLine("When the timer ends, close your eyes and try to clear your mind. Since your eyes will be closed, you will count slowly in your mind to know when the activity has ended.  Use the countdown in your mind to push away other thoughts.  This activity is best with a long activity duration.\n");
        animation.DisplayCountdownTimer(GetPauseDurationInSeconds());
        Console.WriteLine("\n");

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Close your eyes and clear your mind..."); 

            Thread.Sleep(GetMultipleOfPauseDurationInSeconds(1000));
        }

        Console.WriteLine($"\nYou should open your eyes!\n");

        Console.WriteLine("Well done!!");
        Console.WriteLine("\n\n");
        Thread.Sleep(2000);

        Console.WriteLine(GetAfterActivityMessage());
        animation.DisplayDefaultSpinnerForCountdownTimer(4, false);

        DisplayStartMenu();
    }
}