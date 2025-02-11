using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");

        SimpleGoal simpleGoal = new SimpleGoal();

        simpleGoal = simpleGoal.DisplayCreateGoalMenu();

        Console.WriteLine(simpleGoal.GetGoalDisplayString());

        EternalGoal eternalGoal = new EternalGoal();

        eternalGoal = eternalGoal.DisplayCreateGoalMenu();

        Console.WriteLine(eternalGoal.GetGoalDisplayString());

    }
}