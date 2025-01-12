using System;

public class Job
{
    string _company;
    string _jobTitle;
    int _startYear;
    int _endYear;

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company} {_startYear}-{_endYear})");
    }
}