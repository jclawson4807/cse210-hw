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

        Job job2 = new Job();
        job2._jobTitle = "Senior Software Engineer";
        job2._company = "Landvoice";
        job2._startYear = 2021;
        job2._endYear = 2023;

        Resume resume = new Resume();
        resume._name = "James Clawson";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        resume.Display();

    }
}