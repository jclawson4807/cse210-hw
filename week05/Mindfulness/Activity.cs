using System;
using System.Data;

public class Activity
{
    private string _activityName;
    private string _welcomeMessage;
    private string _activityDescriptionMessage;
    private string _howLongInSectionsMessage;

    public Activity()
    {
        _activityName = "Base";
        _welcomeMessage = "Welcome to the base activity.";
        _activityDescriptionMessage = "This is the base activity message, and is a placeholder.";
        _howLongInSectionsMessage = "How long, in sections, would you like for your session?";
    }

    public void SetActivityName(string activityName)
    {
        _activityName = activityName;
    }

    public string GetActivityName()
    {
        return _activityName;
    }

    public void SetWelcomeMessage(string welcomeMessage)
    {
        _welcomeMessage = welcomeMessage;
    }

    public string GetWelcomeMessage()
    {
        return _welcomeMessage;
    }

    public void SetActivityDescriptionMessage(string activityDescriptionMessage)
    {
        _activityDescriptionMessage = activityDescriptionMessage;
    }

    public string GetActivityDescriptionMessage()
    {
        return _activityDescriptionMessage;
    }

    public void SetHowLongMessage(string howLongInSectionsMessage)
    {
        _howLongInSectionsMessage = howLongInSectionsMessage;
    }

    public string GetHowLongMessage()
    {
        return _howLongInSectionsMessage;
    }

    public void DisplayStartMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("\t1. Start breathing activity");    
        Console.WriteLine("\t2. Start reflecting activity");  
        Console.WriteLine("\t3. Start listing activity");  
        Console.WriteLine("\t4. Quit"); 
        Console.Write("Select a choice from the menu: ");  

        string menuOptionString = Console.ReadLine();

        try
        {
            int menuOptionInt = int.Parse(menuOptionString);

            DisplayActivityMenu();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: You must enter an integer value from 1 to 4.  ({e})");

            Thread.Sleep(2000);

            DisplayStartMenu();
        }

    }

    public void DisplayActivityMenu()
    {
        Console.Clear();
        Console.WriteLine($"{_welcomeMessage}\n");
        Console.WriteLine($"{_activityDescriptionMessage}\n");
        Console.Write($"{_howLongInSectionsMessage}"); 

        string howLongString = Console.ReadLine();

        try
        {
            int howLongInt = int.Parse(howLongString);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: You must enter a postive, non zero integer value. ({e})");

            Thread.Sleep(2000);

            DisplayActivityMenu();
        }

    }
}