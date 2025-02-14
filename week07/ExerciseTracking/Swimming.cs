using System;

public class Swimming : Activity
{
    private int _numberOfLaps;
    private int _lapLengthInMeters = 50; //@TASK - is this needed?

    public Swimming(DateTime activityDate, int activityDurationInMinutes, int numberOfLaps) : base(activityDate: activityDate, activityDurationInMinutes: activityDurationInMinutes)
    {
        _numberOfLaps = numberOfLaps;
        SetActivityName("Swimming");
    }

    public int GetNumberOfLaps()
    {
        return _numberOfLaps;
    }

    public override double GetDistance()
    {
        double distance = GetNumberOfLaps() * 50;
        distance = distance/1000;
        distance = distance * 0.62;
        
        return Math.Round(distance, 2); 
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