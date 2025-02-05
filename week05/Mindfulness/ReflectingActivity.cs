using System;

public class ReflectingActivity: Activity
{
    public ReflectingActivity()
    {
        SetActivityName("Reflecting Activity");
        SetWelcomeMessage("Welcome to the Reflecting Activity.");
        SetActivityDescriptionMessage("This activity will help you reflect on times in your life when you have shown strength and resilience.  This will help you recognize the power you have and how you can use it in other aspects of your life.");
        SetHowLongMessage("How long, in sections, would you like for your session?");
        SetAfterActivityMessage("You have completed another ", "seconds of the Reflecting Activity.  Good job!");
    }
}