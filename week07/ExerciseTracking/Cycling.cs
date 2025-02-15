using System;

public class Cycling : Activity
{
    private double _speedInMph;

    public Cycling(DateTime activityDate, int activityDurationInMinutes, double speedInMph) : base(activityDate: activityDate, activityDurationInMinutes: activityDurationInMinutes)
    {
        _speedInMph = speedInMph;
        SetActivityName("Cycling");
    }

    public override double GetDistance()
    {
        double distanceInMiles = (GetSpeed() * GetActivityDuration()) / 60;
        
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