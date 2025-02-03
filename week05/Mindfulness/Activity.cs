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
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: You must enter an integer value from 1 to 4.  ({e})");

            Thread.Sleep(2000);

            DisplayStartMenu();
        }

    }
}