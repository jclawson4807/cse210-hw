using System;

public class BreathingActivity: Activity
{
    public BreathingActivity()
    {
        SetActivityName("Breathing Activity");
        SetWelcomeMessage("Welcome to the Breathing Activity.");
        SetActivityDescriptionMessage("This activity will help you relax by walking you through breathing in and out slowly.  Clear your mind and focus on your breathing.");
        SetHowLongMessage("How long, in sections, would you like for your session?");
        SetAfterActivityMessage("You have completed another ", "seconds of the Breathing Activity.  Good job!");
    }
}