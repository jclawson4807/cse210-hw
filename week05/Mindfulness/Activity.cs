using System;
using System.Data;

public class Activity
{
    private string _activityName;
    private string _welcomeMessage;
    private string _activityDescriptionMessage;
    private string _howLongInSectionsMessage;
    private string _afterActivityMessage;

    private int _pauseDurationInSeconds = 4;

    private int _activityDurationInSeconds = 0;

    private Animation _animation = new Animation();
    Random _random = new Random();

    public Activity()
    {
        _activityName = "Base";
        _welcomeMessage = "Welcome to the base activity.";
        _activityDescriptionMessage = "This is the base activity message, and is a placeholder.";
        _howLongInSectionsMessage = "How long, in sections, would you like for your session?";
        _afterActivityMessage = "You have completed the base activity.  Well done.";
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

    public void SetAfterActivityMessage(string afterActivityMessage)
    {
        _afterActivityMessage = afterActivityMessage;
    }

    public string GetAfterActivityMessage()
    {
        return _afterActivityMessage;
    }

    public void DisplayStartMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu Options:");
        Console.WriteLine(" 1. Start breathing activity");    
        Console.WriteLine(" 2. Start reflecting activity");  
        Console.WriteLine(" 3. Start listing activity");  
        Console.WriteLine(" 4. Quit"); 
        Console.Write("Select a choice from the menu: ");  

        string menuOptionString = Console.ReadLine();

        try
        {
            int menuOptionInt = int.Parse(menuOptionString);

            if (menuOptionInt == 1)
            {
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.DisplayActivityMenu();
            }
            else if (menuOptionInt == 2)
            {
                ReflectingActivity reflectingActivity = new ReflectingActivity();
                reflectingActivity.DisplayActivityMenu();
            }
            else if (menuOptionInt == 3)
            {
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.DisplayActivityMenu();
            }
            else if (menuOptionInt == 4)
            {
                Console.WriteLine("Quitting Mindfulness Program.  Good Bye.");
                System.Environment.Exit(1);
            }
            else
            {
                DisplayActivityMenu();
            }
            
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
        Console.Write($"{_howLongInSectionsMessage} "); 

        string howLongString = Console.ReadLine();

        try
        {
            _activityDurationInSeconds = int.Parse(howLongString);

            int spinnerType = _random.Next(1, 8);

            DisplayActivityStartMessage("Get Ready...", spinnerType);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: You must enter a postive, non zero integer value. ({e})");

            Thread.Sleep(2000);

            DisplayActivityMenu();
        }
    }

    public bool DisplayActivityStartMessage(string startMessage, int spinnerType, bool progressiveSpinner = false, bool eraseProgress = true)
    {
        Console.Clear();
        Console.WriteLine(startMessage);

        if (spinnerType == 1)
        {
            _animation.DisplayArrowSpinnerForCountdownTimer(totalNumberOfSeconds: _pauseDurationInSeconds, progressiveSpinner: progressiveSpinner);
        }
        else if (spinnerType == 2)
        {
            _animation.DisplayDirectionalArrowSpinnerForCountdownTimer(totalNumberOfSeconds: _pauseDurationInSeconds, progressiveSpinner: progressiveSpinner);
        }
        else if (spinnerType == 3)
        {
            _animation.DisplayLevelBarSpinnerForCountdownTimer(totalNumberOfSeconds: _pauseDurationInSeconds, progressiveSpinner: progressiveSpinner);
        }
        else if (spinnerType == 4)
        {
            _animation.DisplayRightLeftBarSpinnerForCountdownTimer(totalNumberOfSeconds: _pauseDurationInSeconds, progressiveSpinner: progressiveSpinner);
        }
        else if (spinnerType == 5)
        {
            _animation.DisplayLevelSpinnerForCountdownTimer(totalNumberOfSeconds: _pauseDurationInSeconds, progressiveSpinner: progressiveSpinner, eraseProgress: eraseProgress);
        }
        else if (spinnerType == 6)
        {
            _animation.DisplayShruggingForCountdownTimer(totalNumberOfSeconds: _pauseDurationInSeconds);
        }
        else if (spinnerType == 7)
        {
            _animation.DisplayDefaultSpinnerForCountdownTimer(totalNumberOfSeconds: _pauseDurationInSeconds, progressiveSpinner: progressiveSpinner);
        }

        return true;
    }
}