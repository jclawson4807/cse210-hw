using System;
using System.Security.Cryptography.X509Certificates;

public class Animation
{
    public void DisplayCountdownTimer(int totalNumberOfSeconds)
    {
        for (int i = totalNumberOfSeconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            
            if (i > 9)
            {
                Console.Write("\b\b  \b\b");
            }
            else
            {
                Console.Write("\b \b");
            }
        }
    }

    public void DisplayProgressiveCountdownTimer(int totalNumberOfSeconds)
    {
        for (int i = totalNumberOfSeconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            
            if (i > 9)
            {
                Console.Write("\b\b   \b\b");
            }
            else
            {
                Console.Write("\b  \b");
            }
        }
    }

    public void DisplayArrowSpinnerForCountdownTimer(int totalNumberOfSeconds, bool progressiveSpinner = false)
    {
        List<string> spinnerCharacters = new List<string>();

        spinnerCharacters.Add("<");
        spinnerCharacters.Add("^");
        spinnerCharacters.Add(">");
        spinnerCharacters.Add("v");

        int i = 0;
        int c = spinnerCharacters.Count;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(totalNumberOfSeconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerCharacters[i]);
            Thread.Sleep(1000);

            if (progressiveSpinner)
            {
                Console.Write("\b  \b");
            }
            else
            {
                Console.Write("\b \b");
            }

            i++;

            if (i >= c)
            {
                i = 0;
            }
        }
    }
}