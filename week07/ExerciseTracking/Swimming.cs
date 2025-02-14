using System;

public class Swimming : Activity
{
    private int _numberOfLaps;
    private int _lapLengthInMeters = 50; //@TASK - is this needed?

    public int GetNumberOfLaps()
    {
        return _numberOfLaps;
    }

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
        // WON'T THIS BE THE SAME IN ALL CLASSES?  WHY CAN'T THIS BE IN THE BASE CLASS?
        return GetActivityDuration() / GetDistance();
    }
}