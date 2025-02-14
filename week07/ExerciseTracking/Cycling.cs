using System;

public class Cycling : Activity
{
    private double _speedInMph;
    private double _distanceInMiles;

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