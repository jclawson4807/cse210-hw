using System;

public abstract class Goal
{
    private string _goalType = "Goal";
    private string _title;
    private string _description;
    private int _points;
    private bool _isComplete = false;

    private int _pointTotal = 0;

    public Goal()
    {

    }

    public Goal(string title, string description, int points)
    {
        _title = title;
        _description = description;
        _points = points;
    }

    public string GetGoalType()
    {
        return _goalType;
    }

    public void SetTitle(string title)
    {
        _title = title;
    }

    public string GetTitle()
    {
        return _title;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public string GetDescription()
    {
        return _description;
    }

    public void SetPoints(int points)
    {
        _points = points;
    }

    public int GetPoints()
    {
        return _points;
    }

    public virtual int RecordEvent()
    {
        if (GetIsGoalComplete() == false)
        {
            return GetPointTotal();
        }
        else
        {
            SetIsGoalComplete(true);
            return IncrementPointTotal(GetPoints());  
        }
    }

    public void SetIsGoalComplete(bool isGoalComplete)
    {
        _isComplete = isGoalComplete;
    }

    public bool GetIsGoalComplete()
    {
        return _isComplete;
    }

    public int IncrementPointTotal(int incrementAmount)
    {
        _pointTotal += incrementAmount;  
        return _pointTotal;  
    }

    public int GetPointTotal()
    {
        return _pointTotal;
    }

    public abstract Goal DisplayCreateGoalMenu();

    public abstract string GetGoalDisplayString();

    public int DisplayGoalMenu(int globalPointTotal)
    {
        // Console.Clear();

        if (globalPointTotal == 1)
        {
            Console.WriteLine("You have 1 point.");
        }
        else
        {
            Console.WriteLine($"You have {globalPointTotal} points.");
        }

        Console.WriteLine("\nMenu Options:");
        Console.WriteLine("\t1. Create New Goal");
        Console.WriteLine("\t2. List Goals");
        Console.WriteLine("\t3. Save Goals");
        Console.WriteLine("\t4. Load Goals");
        Console.WriteLine("\t5. Record Event");
        Console.WriteLine("\t6. Quit");
        Console.Write("Select a choice from the menu: ");
        
        try
        {
            string menuSelectionString = Console.ReadLine();

            int menuSelectionInt = int.Parse(menuSelectionString);

            return menuSelectionInt;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: You must enter an integer value between 1 and 6. ({e})");

            Thread.Sleep(2000);

            return DisplayGoalMenu(globalPointTotal);
        }
    }
}