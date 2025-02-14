using System;

public class Running : Activity
{
    private double _distanceInMiles;

    // NOTE - from assignment - For each activity, they do not want to store this information, but they would like to be able to get following information (by calculation if it is not stored directly):
    // does this mean we are not supposed to store the distance?

    public Running(DateTime activityDate, int activityDurationInMinutes, double distanceInMiles) : base(activityDate: activityDate, activityDurationInMinutes: activityDurationInMinutes)
    {
        _distanceInMiles = distanceInMiles;
        SetActivityName("Running");
    }

    public override double GetDistance()
    {
        return _distanceInMiles;   
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetActivityDuration()) * 60;
    }

    public override double GetPace()
    {
        // WON'T THIS BE THE SAME IN ALL CLASSES?  WHY CAN'T THIS BE IN THE BASE CLASS?
        return GetActivityDuration() / GetDistance();
    }
}