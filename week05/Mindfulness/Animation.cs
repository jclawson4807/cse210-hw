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
}