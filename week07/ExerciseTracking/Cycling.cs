using System;

public class Cycling : Activity
{
    private double _speedInMph;

    // NOTE - from assignment - For each activity, they do not want to store this information, but they would like to be able to get following information (by calculation if it is not stored directly):
    // does this mean we are not supposed to store the distance?

    public Cycling(DateTime activityDate, int activityDurationInMinutes, double speedInMph) : base(activityDate: activityDate, activityDurationInMinutes: activityDurationInMinutes)
    {
        _speedInMph = speedInMph;
        SetActivityName("Cycling");
    }

    public override double GetDistance()
    {
        double distanceInMiles = GetSpeed() * GetActivityDuration();
        
        return Math.Round(distanceInMiles, 2);   
    }

    public override double GetSpeed()
    {
        return Math.Round(_speedInMph, 2);
    }

    public override double GetPace()
    {
        // WON'T THIS BE THE SAME IN ALL CLASSES?  WHY CAN'T THIS BE IN THE BASE CLASS?
        return Math.Round((GetActivityDuration() / GetDistance()), 2);
    }
}