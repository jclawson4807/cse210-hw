using System;

class Program
{
    /*
    Exceeds Core Requirements
    1) Created an Animation class with the default spinner, a countdown timer, and 6 other animations
    2) Some animations occur in a static locations, and other have an option to move across the screen on the same line to the right
    3) Some animations also have an option to erase the previous character while moving across the screen, or leaving the character so that there is a series of characters in a row
    4) One of the animations is multi-character ascii art which begins as a shrug and does the wave
    5) The spinner animation which is shown after the activity start message is selected randomly.
    6) I added two additional mindfullness activities
    7) In addition to using Inheritance, I also used method overriding for the MindfulnessActivity method, meaning that a method stub is defined in the Activity class, and implemented differently in each derived class.  This simplies calling the activity.
    */

    static void Main(string[] args)
    {
        Activity activity = new Activity();
        activity.DisplayStartMenu();
    }
}