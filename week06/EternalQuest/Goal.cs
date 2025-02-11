using System;

public abstract class Goal
{
    private string _goalType = "Goal";
    private string _title;
    private string _description;
    private int _points;
    private bool _isComplete = false;

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

    public void SetIsGoalComplete(bool isGoalComplete)
    {
        _isComplete = isGoalComplete;
    }

    public bool GetIsGoalComplete()
    {
        return _isComplete;
    }

    public abstract Goal DisplayCreateGoalMenu();

    public abstract string GetGoalDisplayString();
}