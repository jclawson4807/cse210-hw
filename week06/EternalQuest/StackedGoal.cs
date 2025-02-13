using System;

public class StackedGoal : Goal
{
    private DateTime _lastModifiedDate = DateTime.Now;
    private int _originalPoints;
    
    public StackedGoal() : base ()
    {
        SetGoalType("StackedGoal");
    }
    
    public StackedGoal(string title, string description, int originalPoints, int currentPoints) : base(title: title, description: description, points: currentPoints)
    {
        SetGoalType("StackedGoal");
        Console.WriteLine("Created Stacked Goal");
        _originalPoints = originalPoints;
    }

    public int GetOriginalPoints()
    {
        return _originalPoints;
    }

    public void SetOriginalPoints(int originalPoints)
    {
        _originalPoints = originalPoints;
    }

    public DateTime GetLastModifiedDate()
    {
        return _lastModifiedDate;
    }

    public void SetLastModifiedDate(DateTime lastModifiedDate)
    {
        _lastModifiedDate = lastModifiedDate;
    }

    public override int RecordEvent()
    {
        int points = GetPoints();

        DateTime currentDate = DateTime.Now;

        int dateDiffInHours = (currentDate - GetLastModifiedDate()).Hours;

        if (dateDiffInHours > 24)
        {
            // the number of points earned resets after 24 hours of no recorded activity
            SetPoints(GetOriginalPoints());
            points = GetPoints();
        }
        else
        {
            // every time you complete the goal with less than 24 hours in between recorded activity events, the total points increments by the original point value
            SetPoints(GetPoints() + GetOriginalPoints());
        }

        return IncrementPointTotal(points);  
    }

    public override StackedGoal DisplayCreateGoalMenu()
    {
        Console.Clear();
        Console.Write("What is the name of your goal? ");
        string title = Console.ReadLine();

        Console.Write("\nWhat is a short description of your goal? ");
        string description = Console.ReadLine();

        Console.Write("\nWhat is the amount of points associated with this goal? ");
        string numberOfPoints = Console.ReadLine();

        int points = int.Parse(numberOfPoints);

        StackedGoal StackedGoal = new StackedGoal(title: title, description: description, originalPoints: points, currentPoints: points);

        return StackedGoal;
    }

    public override string GetStringRepresentation()
    {
        return $"StackedGoal:{GetTitle()}^{GetDescription()}^{GetPoints()}^false^{GetOriginalPoints()}^{GetLastModifiedDate().ToString("yyyy-MM-dd HH:mm:ss")}";
    }

    public override string GetGoalDisplayString()
    {
        string goalDisplayString = $"[ ] {GetTitle()} ({GetDescription()})"; 

        return goalDisplayString;
    }

    public override StackedGoal DisplayGoalEditor()
    {
        StackedGoal newStackedGoal = new StackedGoal();
        
        Console.Write($"\nPlease enter the new Goal name, or hit enter to use the existing value: ({GetTitle()}): ");

        string title = Console.ReadLine();

        if (title.Trim().Length > 0)
        {
            newStackedGoal.SetTitle(title.Trim());
        }
        else
        {
            newStackedGoal.SetTitle(GetTitle());     
        }

        Console.Write($"\nPlease enter the new description, or hit enter to use the existing value: ({GetDescription()}): ");

        string description = Console.ReadLine();

        if (description.Trim().Length > 0)
        {
            newStackedGoal.SetDescription(description.Trim());
        }
        else
        {
            newStackedGoal.SetDescription(GetDescription());
        }

        Console.Write($"\nPlease enter the new point value for this goal, or hit enter to use the existing value: ({GetPoints()}): ");

        string pointsString = Console.ReadLine();

        if (pointsString.Length > 0)
        {
            int points = ExtractIntFromString(pointsString);

            newStackedGoal.SetPoints(points);
        }
        else
        {
            newStackedGoal.SetPoints(GetPoints());    
        }

        return newStackedGoal;
    }
}