using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.DisplayPrimaryMenu();

        /*
        Exceeding expectations

        1) Added new goal type - StackedGoal - every time you record an event for that goal within 24 hours of the last time you recorded an event for that goal, the next point award increments by the original point amount.  The point value resets to the original point amount if the gap is longer than 24 hours.
        2) Added a goal editor.  It will not allow you to edit completed goals.  This tool requires the use of class casting from the base to the derived class.
        3) I added checks in many places to prevent the program from crashing due to user error.  For example, the system verifies a file exists before reading from it.  It also uses try catch blocks for int conversions when getting numbers entered by the user from the prompt.
        4) For list views, I added a "hit any key" requirement so that the list would be displayed until the user responded.
        */

    }
}