using System;

public abstract class Activity
{
    private DateTime _activityDate;
    private int _activityDurationInMinutes;

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public DateTime GetActivityDate()
    {
        return _activityDate;
    }

    public int GetActivityDuration()
    {
        return _activityDurationInMinutes;
    }

    public string GetSummary()
    {

    }

}
