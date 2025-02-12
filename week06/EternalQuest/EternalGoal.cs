using System;

public class EternalGoal : Goal
{
    public EternalGoal() : base ()
    {

    }
    
    public EternalGoal(string title, string description, int points) : base(title: title, description: description, points: points)
    {
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
}