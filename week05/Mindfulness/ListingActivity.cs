using System;

public class ListingActivity: Activity
{
    private string _activityName;
    private string _welcomeMessage;
    private string _activityDescriptionMessage;
    private string _howLongInSectionsMessage;

    public ListingActivity()
    {
        SetActivityName("Listing Activity");
        SetWelcomeMessage("Welcome to the Listing Activity.");
        SetActivityDescriptionMessage("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        SetHowLongMessage("How long, in sections, would you like for your session?");
        SetAfterActivityMessage("You have completed the Listing Activity.  Well done.");
    }
}