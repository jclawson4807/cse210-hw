using System;

public class Cycling : Activity
{
    private double _speedInMph;
    private double _distanceInMiles;

    public Cycling(DateTime activityDate, int activityDurationInMinutes, double distanceInMiles, double speedInMph) : base(activityDate: activityDate, activityDurationInMinutes: activityDurationInMinutes)
    {
        _distanceInMiles = distanceInMiles;
        _speedInMph = speedInMph;
        SetActivityName("Cycling");
    }

    public override double GetDistance()
    {
        return _distanceInMiles;   
    }

    public override double GetSpeed()
    {
        return _speedInMph;
    }

    public override double GetPace()
    {
        // WON'T THIS BE THE SAME IN ALL CLASSES?  WHY CAN'T THIS BE IN THE BASE CLASS?
        return GetActivityDuration() / GetDistance();
    }
}