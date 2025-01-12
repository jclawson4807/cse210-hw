using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "BYU";
        job1._startYear = 1991;
        job1._endYear = 1992;

        job1.Display();

    }
}