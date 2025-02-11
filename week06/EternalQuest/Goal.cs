using System;

public abstract class Goal
{
    private string _title;
    private string _description;
    private int _points;
    private bool _isComplete = false;

    public Goal(string title, string description, int points)
    {
        _title = title;
        _description = description;
        _points = points;
    }

    public void SetIsGoalComplete(bool isGoalComplete)
    {
        _isComplete = isGoalComplete;
    }

    public abstract string GetGoalDisplayString();
}