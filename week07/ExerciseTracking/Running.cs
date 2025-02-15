using System;

public class Running : Activity
{
    private double _distanceInMiles;

    public Running(DateTime activityDate, int activityDurationInMinutes, double distanceInMiles) : base(activityDate: activityDate, activityDurationInMinutes: activityDurationInMinutes)
    {
        _distanceInMiles = distanceInMiles;
        SetActivityName("Running");
    }

    public override double GetDistance()
    {
        return Math.Round(_distanceInMiles, 2);   
    }

    public override double GetSpeed()
    {
        return Math.Round(((GetDistance() / GetActivityDuration()) * 60), 2);
    }

    public override double GetPace()
    {
        // WON'T THIS BE THE SAME IN ALL CLASSES?  WHY CAN'T THIS BE IN THE BASE CLASS?
        return Math.Round((GetActivityDuration() / GetDistance()), 2);
    }
}