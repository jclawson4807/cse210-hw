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

    public Goal DisplayCreateGoalMenu()
    {
        Console.Clear();
        Console.Write("What is the name of your goal? ");
        string title = Console.ReadLine();

        Console.Write("\nWhat is a short description of your goal? ");
        string description = Console.ReadLine();

        Console.Write("\nWhat is the amount of points associated with this goal? ");
        string numberOfPoints = Console.ReadLine();

        try
        {
            points = int.Parse(numberOfPoints);

            SimpleGoal simpleGoal = new SimpleGoal(title: title, description: description, points: points);

            return SimpleGoal;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception in {GetGoalType()}: You must enter a positive, non zero integer value. ({e})");

            Thread.Sleep(2000);

            DisplayCreateGoalMenu();
        }
    }

    public string GetGoalDisplayString()
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

        goalDisplayString = $"{goalDisplayString} {GetTitle()} ({GetDescription()})"; 
    }
}