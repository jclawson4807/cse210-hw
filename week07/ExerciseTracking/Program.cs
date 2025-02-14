using System;

class Program
{
    private static List<Activity> _activities = new List<Activity>();

    public static void PopulateActivities()
    {
        Cycling cycling = new Cycling(DateTime.Now, 120, 25, 12.5);
        _activities.Add(cycling);

        Running running = new Running(DateTime.Now, 60, 6);
        _activities.Add(running);

        Swimming swimming = new Swimming(DateTime.Now, 47, 33);
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