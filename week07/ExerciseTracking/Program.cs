using System;

class Program
{
    private static List<Activity> _activities = new List<Activity>();

    public static void PopulateActivities()
    {
        Cycling cycling = new Cycling(activityDate: DateTime.Now, activityDurationInMinutes: 120, speedInMph: 12.5);
        _activities.Add(cycling);

        Running running = new Running(activityDate: DateTime.Now, activityDurationInMinutes: 60, distanceInMiles: 6);
        _activities.Add(running);

        Swimming swimming = new Swimming(activityDate: DateTime.Now, activityDurationInMinutes: 47, numberOfLaps: 33);
        _activities.Add(swimming);
    }

    static void Main(string[] args)
    {
        PopulateActivities();

        foreach (Activity activity in _activities)
        {
            Console.WriteLine(activity.GetSummary());     
        }
    }
}