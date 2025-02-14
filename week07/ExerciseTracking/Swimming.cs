using System;

public class Swimming : Activity
{
    private int _numberOfLaps;
    private int _lapLengthInMeters = 50;

    public override double GetDistance()
    {
        return _numberOfLaps * 50 / 1000 * 0.62;   
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetActivityDuration()) * 60;
    }

    public override double GetPace()
    {
        return GetActivityDuration() / GetDistance();
    }
}