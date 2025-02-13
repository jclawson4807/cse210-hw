using System;

public class EternalGoal : Goal
{
    public EternalGoal() : base ()
    {
        SetGoalType("EternalGoal");
    }
    
    public EternalGoal(string title, string description, int points) : base(title: title, description: description, points: points)
    {
        SetGoalType("EternalGoal");
        Console.WriteLine("Created Eternal Goal");
    }

    public override int RecordEvent()
    {
        return IncrementPointTotal(GetPoints());  
    }

    public override EternalGoal DisplayCreateGoalMenu()
    {
        Console.Clear();
        Console.Write("What is the name of your goal? ");
        string title = Console.ReadLine();

        Console.Write("\nWhat is a short description of your goal? ");
        string description = Console.ReadLine();

        Console.Write("\nWhat is the amount of points associated with this goal? ");
        string numberOfPoints = Console.ReadLine();

        int points = int.Parse(numberOfPoints);

        EternalGoal eternalGoal = new EternalGoal(title: title, description: description, points: points);

        return eternalGoal;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{GetTitle()}^{GetDescription()}^{GetPoints()}^false";
    }

    public override string GetGoalDisplayString()
    {
        string goalDisplayString = $"[ ] {GetTitle()} ({GetDescription()})"; 

        return goalDisplayString;
    }

    public override EternalGoal DisplayGoalEditor()
    {
        EternalGoal newEternalGoal = new EternalGoal();
        
        Console.Write($"\nPlease enter the new Goal name, or hit enter to use the existing value: ({GetTitle()}): ");

        string title = Console.ReadLine();

        if (title.Trim().Length() > 0)
        {
            newEternalGoal.SetTitle(title.Trim());
        }
        else
        {
            newEternalGoal.SetTitle(GetTitle());     
        }

        Console.Write($"\nPlease enter the new description, or hit enter to use the existing value: ({GetDescription()}): ");

        string description = Console.ReadLine();

        if (description.Trim().Length() > 0)
        {
            newEternalGoal.SetDescription(description.Trim());
        }
        else
        {
            newEternalGoal.SetDescription(GetDescription());
        }

        Console.Write($"\nPlease enter the new point value for this goal, or hit enter to use the existing value: ({GetPoints()}): ");

        string pointsString = Console.ReadLine();

        if (pointsString.Length() > 0)
        {
            int points = ExtractIntFromString(pointsString);

            newEternalGoal.SetPoints(points);
        }
        else
        {
            newEternalGoal.SetPoints(GetPoints());    
        }

        return newEternalGoal;
    }
}