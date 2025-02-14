using System;

public class Activity
{
    private DateTime _activityDate;
    private int _activityDuration;

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public DateTime GetActivityDate()
    {
        return _activityDate;
    }

    public int GetActivityDuration()
    {
        return _activityDuration;
    }

    public string GetSummary()
    {
        
    }

}
