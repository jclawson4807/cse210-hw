using System;

class Program
{
    private static List<Goal> _goalList = new List<Goal>();

    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");

        SimpleGoal simpleGoal = new SimpleGoal();

        simpleGoal = simpleGoal.DisplayCreateGoalMenu();

        _goalList.Add(simpleGoal);

        EternalGoal eternalGoal = new EternalGoal();

        eternalGoal = eternalGoal.DisplayCreateGoalMenu();

        _goalList.Add(eternalGoal);

        ChecklistGoal checklistGoal = new ChecklistGoal();

        checklistGoal = checklistGoal.DisplayCreateGoalMenu();

        _goalList.Add(checklistGoal);

        int actionInt = checklistGoal.DisplayGoalMenu();

        if (actionInt == 2)
        {
            ListGoals();
        }

        

        /*
        @TODO - 
        2) create the primary menu
        3) adding code to store current points
        4) write code in base and derived classes associated with marking a goal done and getting back points
        5) add save and load functionality
            this will require a version of the get goal string that returns a storable version rather than the display version
        6) add custom functionality - add a goal type where the score increases based on how many times it is completed in a given day or how much you exceeded a base amount .... such as drinking water, walking, etc. perhaps a ranking system, something that prevents a goal from being accomplished too many times in a given day, a goal editor
        */

    }

    static void ListGoals()
    {
        Console.Clear();
        Console.WriteLine("The goals are:");

        foreach (Goal goal in _goalList)
        {
            Console.WriteLine(goal.GetGoalDisplayString());     
        }
    }
}