using System;

public class SimpleGoal : Goal
{
    public SimpleGoal() : base ()
    {

    }
    
    public SimpleGoal(string title, string description, int points) : base(title: title, description: description, points: points)
    {
        Console.WriteLine("Created Simple Goal");
    }

    public override SimpleGoal DisplayCreateGoalMenu()
    {
        Console.Clear();
        Console.Write("What is the name of your goal? ");
        string title = Console.ReadLine();

        Console.Write("\nWhat is a short description of your goal? ");
        string description = Console.ReadLine();

        Console.Write("\nWhat is the amount of points associated with this goal? ");
        string numberOfPoints = Console.ReadLine();

        int points = int.Parse(numberOfPoints);

        SimpleGoal simpleGoal = new SimpleGoal(title: title, description: description, points: points);

        return simpleGoal;
    }

    public override string GetStringRepresentation()
    {
        string completionStateString = "false";

        if (GetIsGoalComplete())
        {
            completionStateString = "true";    
        }

        return $"SimpleGoal:{GetTitle()}^{GetDescription()}^{GetPoints()}^{completionStateString}";
    }

    public override string GetGoalDisplayString()
    {
        string goalDisplayString = "[";

        if (GetIsGoalComplete())
        {
            goalDisplayString += "X";    
        }
        else
        {
            goalDisplayString += " ";    
        }

        goalDisplayString = $"{goalDisplayString}] {GetTitle()} ({GetDescription()})"; 

        return goalDisplayString;
    }
}