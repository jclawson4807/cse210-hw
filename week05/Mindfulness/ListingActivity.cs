using System;

public class ListingActivity: Activity
{
    private List<string> _promptQuestions = new List<string>();
    private List<string> _responses = new List<string>();
    
    public void PopulatePromptQuestions()
    {
        _promptQuestions.Clear();

        _promptQuestions.Add(" --- Who are people that you appreciate? ---"); 
        _promptQuestions.Add(" --- What are personal strengths of yours? ---"); 
        _promptQuestions.Add(" --- Who are people that you have helped this week? ---"); 
        _promptQuestions.Add(" --- When have you felt the Holy Ghost this month?  ---"); 
        _promptQuestions.Add(" --- Who are some of your personal heroes?  ---"); 
    }

    public ListingActivity()
    {
        SetActivityName("Listing Activity");
        SetWelcomeMessage("Welcome to the Listing Activity.");
        SetActivityDescriptionMessage("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        SetHowLongMessage("How long, in sections, would you like for your session?");
        SetAfterActivityMessage("You have completed another ", " seconds of the Listing Activity.  Good job!");
    }

    public override void MindfulnessActivity()
    {
        Console.Clear();
        
        PopulatePromptQuestions();

        _responses.Clear();

        Console.WriteLine("");
        Console.WriteLine("");

        Animation animation = GetAnimation();
        Random random = GetRandom();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetActivityDurationInSeconds());

        Console.WriteLine("List as many responses as you can to the following prompt:\n");

        Console.WriteLine(_promptQuestions[random.Next(0, _promptQuestions.Count)]);

        Console.Write("\nYou may begin in: ");
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

        Console.WriteLine($"\nYou listed {_responses.Count()} items!\n");

        Console.WriteLine("Well done!!");
        Console.WriteLine("\n\n");
        Thread.Sleep(2000);

        Console.WriteLine(GetAfterActivityMessage());
        animation.DisplayDefaultSpinnerForCountdownTimer(4, false);

        DisplayStartMenu();
    }
}