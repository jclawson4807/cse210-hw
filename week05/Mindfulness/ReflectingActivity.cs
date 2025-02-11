using System;

public class ReflectingActivity: Activity
{
    private List<string> _promptQuestions = new List<string>();
    private List<string> _reflectionQuestions = new List<string>();


    public void PopulatePromptQuestions()
    {
        _promptQuestions.Clear();

        _promptQuestions.Add(" --- Think of a time when you stood up for someone else. ---"); 
        _promptQuestions.Add(" --- Think of a time when you did something really difficult. ---"); 
        _promptQuestions.Add(" --- Think of a time when you helped someone in need. ---"); 
        _promptQuestions.Add(" --- Think of a time when you did something truly selfless.  ---");   
    }
    
    public void PopulateReflectionQuestions()
    {
        _reflectionQuestions.Clear();

        _reflectionQuestions.Add("Why was this experience meaningful to you?"); 
        _reflectionQuestions.Add("Have you ever done anything like this before?"); 
        _reflectionQuestions.Add("How did you get started?"); 
        _reflectionQuestions.Add("How did you feel when it was complete?"); 
        _reflectionQuestions.Add("What made this time different than other times when you were not as successful?"); 
        _reflectionQuestions.Add("What is your favorite thing about this experience?"); 
        _reflectionQuestions.Add("What could you learn from this experience that applies to other situations?"); 
        _reflectionQuestions.Add("What did you learn about yourself through this experience?"); 
        _reflectionQuestions.Add("How can you keep this experience in mind in the future?");  
    }

    public ReflectingActivity()
    {
        SetActivityName("Reflecting Activity");
        SetWelcomeMessage("Welcome to the Reflecting Activity.");
        SetActivityDescriptionMessage("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        SetHowLongMessage("How long, in sections, would you like for your session?");
        SetAfterActivityMessage("You have completed another ", " seconds of the Reflecting Activity.  Good job!");
    }

    public override void MindfulnessActivity()
    {
        Console.Clear();
        
        PopulatePromptQuestions();
        PopulateReflectionQuestions();

        Console.WriteLine("");
        Console.WriteLine("");

        Animation animation = GetAnimation();
        Random random = GetRandom();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetActivityDurationInSeconds());

        Console.WriteLine("Consider the following prompt:\n");

        Console.WriteLine(_promptQuestions[random.Next(0, _promptQuestions.Count)]);

        Console.WriteLine("\nWhen you have something in mind, press enter to continue.\n");

        string userResponseString = Console.ReadLine();

        Console.WriteLine("Now ponder each of the following questions as they related to this experience.\n");

        Console.Clear();

        while (DateTime.Now < endTime)
        {
            int randomReflectionQuestionIndex = random.Next(0, _reflectionQuestions.Count);

            Console.Write($"{_reflectionQuestions[randomReflectionQuestionIndex]} ");

            _reflectionQuestions.RemoveAt(randomReflectionQuestionIndex);
            
            animation.DisplayRightLeftBarSpinnerForCountdownTimer(totalNumberOfSeconds: GetMultipleOfPauseDurationInSeconds(), progressiveSpinner: true);

            Console.WriteLine("\n\n");
        }

        Console.WriteLine("Well done!!");
        Console.WriteLine("\n\n");
        Thread.Sleep(2000);

        Console.WriteLine(GetAfterActivityMessage());
        animation.DisplayDefaultSpinnerForCountdownTimer(4, false);

        DisplayStartMenu();
    }
}