using System;

public class SimpleGoal : Goal
{
    public SimpleGoal() : base ()
    {
        SetGoalType("SimpleGoal");
    }
    
    public SimpleGoal(string title, string description, int points) : base(title: title, description: description, points: points)
    {
        SetGoalType("SimpleGoal");
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

        int points = ExtractIntFromString(numberOfPoints);

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

    public override SimpleGoal DisplayGoalEditor()
    {
        SimpleGoal newSimpleGoal = new SimpleGoal();
        
        Console.Write($"\nPlease enter the new Goal name, or hit enter to use the existing value: ({GetTitle()}): ");

        string title = Console.ReadLine();

        if (title.Trim().Length > 0)
        {
            newSimpleGoal.SetTitle(title.Trim());
        }
        else
        {
            newSimpleGoal.SetTitle(GetTitle());     
        }

        Console.Write($"\nPlease enter the new description, or hit enter to use the existing value: ({GetDescription()}): ");

        string description = Console.ReadLine();

        if (description.Trim().Length > 0)
        {
            newSimpleGoal.SetDescription(description.Trim());
        }
        else
        {
            newSimpleGoal.SetDescription(GetDescription());
        }

        if (GetIsGoalComplete())
        {
            newSimpleGoal.SetIsGoalComplete(true); 
            newSimpleGoal.SetPoints(GetPoints());     
        }
        else
        {
            Console.Write($"\nPlease enter the new point value for this goal, or hit enter to use the existing value: ({GetPoints()}): ");

            string pointsString = Console.ReadLine();

            if (pointsString.Length > 0)
            {
                int points = ExtractIntFromString(pointsString);

                newSimpleGoal.SetPoints(points);
            }
            else
            {
                newSimpleGoal.SetPoints(GetPoints());    
            }
        }

        return newSimpleGoal;
    }
}