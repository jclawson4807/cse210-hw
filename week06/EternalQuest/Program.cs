using System;

class Program
{
    private static List<Goal> _goalList = new List<Goal>();
    private static int _globalPointTotal = 0;

    public static int IncrementGlobalPointTotal(int incrementAmount)
    {
        _globalPointTotal += incrementAmount;
        return _globalPointTotal;
    }

    static void Main(string[] args)
    {
        SimpleGoal initialGoal = new SimpleGoal();

        int actionInt = initialGoal.DisplayGoalMenu();

        if (actionInt == 1)
        {

        }
        else if (actionInt == 2)
        {
            ListGoals();
        }

        

        /*
        @TODO - 
        2) create the primary menu
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