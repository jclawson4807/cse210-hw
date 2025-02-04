using System;

public class BreathingActivity: Activity
{
    private string _activityName;
    private string _welcomeMessage;
    private string _activityDescriptionMessage;
    private string _howLongInSectionsMessage;

    public BreathingActivity()
    {
        SetActivityName("Breathing Activity");
        SetWelcomeMessage("Welcome to the Breathing Activity.");
        SetActivityDescriptionMessage("This activity will help you relax by walking you through breathing in and out slowly.  Clear your mind and focus on your breathing.");
        SetHowLongMessage("How long, in sections, would you like for your session?");
        SetAfterActivityMessage("You have completed the Breathing Activity.  Well done.");
    }
}