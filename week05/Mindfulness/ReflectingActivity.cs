using System;

public class ReflectingActivity: Activity
{
    private List<string> _reflectionQuestions = new List<string>();


    public void PopulateReflectionQuestions()
    {
        _reflectionQuestions.Clear();

        _reflectionQuestions.Add(" --- Think of a time when you stood up for someone else. ---"); 
        _reflectionQuestions.Add(" --- Think of a time when you did something really difficult. ---"); 
        _reflectionQuestions.Add(" --- Think of a time when you helped someone in need. ---"); 
        _reflectionQuestions.Add(" --- Think of a time when you did something truly selfless.  ---");   
    }

    public ReflectingActivity()
    {
        SetActivityName("Reflecting Activity");
        SetWelcomeMessage("Welcome to the Reflecting Activity.");
        SetActivityDescriptionMessage("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        SetHowLongMessage("How long, in sections, would you like for your session?");
        SetAfterActivityMessage("You have completed another ", " seconds of the Reflecting Activity.  Good job!");
    }

    public void MindfulnessActivity()
    {
        PopulateReflectionQuestions();

        Console.WriteLine("");
        Console.WriteLine("");

        Animation animation = GetAnimation();
        Random random = GetRandom();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetActivityDurationInSeconds());

        Console.WriteLine("Consider the following prompt:\n");

        Console.WriteLine(_reflectionQuestions[random.Next(0, _reflectionQuestions.Count)]);

        Console.WriteLine("\nWhen you have something in mind, press enter to continue.\n");

        string userResponseString = Console.ReadLine();

        Console.WriteLine("Now ponder each of the following questions as they related to this experience.");

        Console.WriteLine("Well done!!");
        animation.DisplayDefaultSpinnerForCountdownTimer(4, false);
        Console.WriteLine("\n\n");

        Console.WriteLine(GetAfterActivityMessage());

        Thread.Sleep(2000);

        DisplayStartMenu();
    }
}