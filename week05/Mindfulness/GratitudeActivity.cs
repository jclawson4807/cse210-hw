using System;

public class GratitudeActivity: Activity
{
    private List<string> _responses = new List<string>();

    public GratitudeActivity()
    {
        SetActivityName("Gratitude Activity");
        SetWelcomeMessage("Welcome to the Gratitude Activity.");
        SetActivityDescriptionMessage("This activity will help you feel gratitude by thinking of someone who has blessed your life, and things that this person has done that you are grateful for.");
        SetHowLongMessage("How long, in sections, would you like for your session?");
        SetAfterActivityMessage("You have completed another ", " seconds of the Gratitude Activity.  Good job!");
    }

    public override void MindfulnessActivity()
    {
        Console.Clear();
        _responses.Clear();

        Console.WriteLine("");
        Console.WriteLine("");

        Animation animation = GetAnimation();
        Random random = GetRandom();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetActivityDurationInSeconds());

        Console.WriteLine("Name someone who has blesssed your life:\n");

        string personsName = Console.ReadLine();

        Console.Write($"\nNow think of ways in which {personsName} has blessed your life.  You will have the opportunity to list them in:");
        animation.DisplayCountdownTimer(GetPauseDurationInSeconds());
        Console.WriteLine("\n");

        while (DateTime.Now < endTime)
        {
            string userResponseString = Console.ReadLine();

            if (userResponseString.Trim().Length > 0)
            {
                _responses.Add(userResponseString);
            } 
        }

        Console.WriteLine($"\nYou listed {_responses.Count()} ways in which {personsName} blessed your life!\n");

        Console.WriteLine("Well done!!");
        Console.WriteLine("\n\n");
        Thread.Sleep(2000);

        Console.WriteLine(GetAfterActivityMessage());
        animation.DisplayDefaultSpinnerForCountdownTimer(4, false);

        DisplayStartMenu();
    }
}