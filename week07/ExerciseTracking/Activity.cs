using System;

public abstract class Activity
{
    private string _activityName;
    private DateTime _activityDate;
    private int _activityDurationInMinutes;

    public Activity(DateTime activityDate, int activityDurationInMinutes)
    {
        _activityDate = activityDate;
        _activityDurationInMinutes = activityDurationInMinutes;
    }

    public void SetActivityName(string activityName)
    {
        _activityName = activityName;
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public string GetActivityName()
    {
        return _activityName;
    }

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
        return $"{GetActivityDate().ToString("dd MMM yyyy")} {GetActivityName()} ({GetActivityDuration()} min)- Distance {GetDistance()} miles, Speed {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }

}
