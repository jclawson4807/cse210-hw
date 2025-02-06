using System;
using System.Data;

public class Activity
{
    private string _activityName;
    private string _welcomeMessage;
    private string _activityDescriptionMessage;
    private string _howLongInSecondsMessage;
    private string _afterActivityMessagePart1;
    private string _afterActivityMessagePart2;

    private int _pauseDurationInSeconds = 4;

    private int _activityDurationInSeconds;

    private Animation _animation = new Animation();
    Random _random = new Random();

    public Activity()
    {
        _activityName = "Base";
        _welcomeMessage = "Welcome to the base activity.";
        _activityDescriptionMessage = "This is the base activity message, and is a placeholder.";
        _howLongInSecondsMessage = "How long, in seconds, would you like for your session?";
        _afterActivityMessagePart1 = "You have completed another ";
        _afterActivityMessagePart2 = " seconds of the base activity.  Good job!";

    }

    public Animation GetAnimation()
    {
        return _animation;
    }

    public Random GetRandom()
    {
        return _random;
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

    public void SetHowLongMessage(string howLongInSecondsMessage)
    {
        _howLongInSecondsMessage = howLongInSecondsMessage;
    }

    public string GetHowLongMessage()
    {
        return _howLongInSecondsMessage;
    }

    public void SetAfterActivityMessage(string afterActivityMessagePart1, string afterActivityMessagePart2)
    {
        _afterActivityMessagePart1 = afterActivityMessagePart1;
        _afterActivityMessagePart2 = afterActivityMessagePart2;
    }

    public string GetAfterActivityMessage()
    {
        return $"{_afterActivityMessagePart1}{_activityDurationInSeconds}{_afterActivityMessagePart2}";
    }

    public int GetActivityDurationInSeconds()
    {
        return _activityDurationInSeconds;
    }

    public void SetActivityDurationInSeconds(int activityDurationInSeconds)
    {
        _activityDurationInSeconds = activityDurationInSeconds;
    }

    public int GetPauseDurationInSeconds()
    {
        return _pauseDurationInSeconds;
    }

    public int GetHalfPauseDurationInSeconds()
    {
        return _pauseDurationInSeconds / 2;
    }

    public int GetMultipleOfPauseDurationInSeconds(int multiplier = 4)
    {
        if (multiplier < 1)
        {
            multiplier = 4;    
        }
        
        return _pauseDurationInSeconds * multiplier;
    }

    public void DisplayStartMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu Options:");
        Console.WriteLine(" 1. Start breathing activity");    
        Console.WriteLine(" 2. Start reflecting activity");  
        Console.WriteLine(" 3. Start listing activity");
        Console.WriteLine(" 4. Start gratitude activity");
        Console.WriteLine(" 5. Start the clear your mind activity");  
        Console.WriteLine(" 6. Quit"); 
        Console.Write("Select a choice from the menu: ");  

        string menuOptionString = Console.ReadLine();

        try
        {
            int menuOptionInt = int.Parse(menuOptionString);

            if (menuOptionInt == 1)
            {
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.DisplayActivityMenu(menuOptionInt);
            }
            else if (menuOptionInt == 2)
            {
                ReflectingActivity reflectingActivity = new ReflectingActivity();
                reflectingActivity.DisplayActivityMenu(menuOptionInt);
            }
            else if (menuOptionInt == 3)
            {
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.DisplayActivityMenu(menuOptionInt);
            }
            else if (menuOptionInt == 4)
            {
                GratitudeActivity gratitudeActivity = new GratitudeActivity();
                gratitudeActivity.DisplayActivityMenu(menuOptionInt);
            }
            else if (menuOptionInt == 5)
            {
                ClosedEyesActivity closedEyesActivity = new ClosedEyesActivity();
                closedEyesActivity.DisplayActivityMenu(menuOptionInt);
            }
            else if (menuOptionInt == 6)
            {
                Console.WriteLine("Quitting Mindfulness Program.  Good Bye.");
                System.Environment.Exit(1);
            }
            else
            {
                DisplayActivityMenu(menuOptionInt);
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception in {_activityName}: You must enter an integer value from 1 to 4.  ({e})");

            Thread.Sleep(2000);

            DisplayStartMenu();
        }

    }

    public void DisplayActivityMenu(int activityTypeID)
    {
        Console.Clear();
        Console.WriteLine($"{_welcomeMessage}\n");
        Console.WriteLine($"{_activityDescriptionMessage}\n");
        Console.Write($"{_howLongInSecondsMessage} "); 

        string howLongString = Console.ReadLine();

        try
        {
            _activityDurationInSeconds = int.Parse(howLongString);

            int spinnerType = _random.Next(1, 8);

            DisplayActivityStartMessage(activityTypeID, _activityDurationInSeconds, "Get Ready...", spinnerType);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception in {_activityName}: You must enter a positive, non zero integer value. ({e})");

            Thread.Sleep(2000);

            DisplayActivityMenu(activityTypeID);
        }
    }

    public bool DisplayActivityStartMessage(int activityType, int activityDurationInSeconds, string startMessage, int spinnerType, bool progressiveSpinner = false, bool eraseProgress = true)
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

        if (activityType == 1)
        {
            BreathingActivity breathingActivity = new BreathingActivity();
            breathingActivity.SetActivityDurationInSeconds(activityDurationInSeconds);
            breathingActivity.MindfulnessActivity();
        }
        else if (activityType == 2)
        {
            ReflectingActivity reflectingActivity = new ReflectingActivity();
            reflectingActivity.SetActivityDurationInSeconds(activityDurationInSeconds);
            reflectingActivity.MindfulnessActivity();
        }
        else if (activityType == 3)
        {
            ListingActivity listingActivity = new ListingActivity();
            listingActivity.SetActivityDurationInSeconds(activityDurationInSeconds);
            listingActivity.MindfulnessActivity();
        }
        else if (activityType == 4)
        {
            GratitudeActivity gratitudeActivity = new GratitudeActivity();
            gratitudeActivity.SetActivityDurationInSeconds(activityDurationInSeconds);
            gratitudeActivity.MindfulnessActivity();
        }
        else if (activityType == 5)
        {
            ClosedEyesActivity closedEyesActivity = new ClosedEyesActivity();
            closedEyesActivity.SetActivityDurationInSeconds(activityDurationInSeconds);
            closedEyesActivity.MindfulnessActivity();
        }

        return true;
    }

    public virtual void MindfulnessActivity()
    {
        Console.WriteLine("Base activity");
    }
}