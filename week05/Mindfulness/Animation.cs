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

    public void DisplayDirectionalArrowSpinnerForCountdownTimer(int totalNumberOfSeconds, bool progressiveSpinner = false)
    {
        List<string> spinnerCharacters = new List<string>();

        spinnerCharacters.Add("←");
        spinnerCharacters.Add("↖");
        spinnerCharacters.Add("↑");
        spinnerCharacters.Add("↗");
        spinnerCharacters.Add("→");
        spinnerCharacters.Add("↘");
        spinnerCharacters.Add("↓");
        spinnerCharacters.Add("↙");

        int i = 0;
        int c = spinnerCharacters.Count;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(totalNumberOfSeconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerCharacters[i]);
            Thread.Sleep(250);

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

    public void DisplayLevelBarSpinnerForCountdownTimer(int totalNumberOfSeconds, bool progressiveSpinner = false)
    {
        List<string> spinnerCharacters = new List<string>();

        spinnerCharacters.Add("▁");
        spinnerCharacters.Add("▃");
        spinnerCharacters.Add("▄");
        spinnerCharacters.Add("▅");
        spinnerCharacters.Add("▆");
        spinnerCharacters.Add("▇");
        spinnerCharacters.Add("█");
        spinnerCharacters.Add("▇");
        spinnerCharacters.Add("▆");
        spinnerCharacters.Add("▅");
        spinnerCharacters.Add("▄");
        spinnerCharacters.Add("▃");

        int i = 0;
        int c = spinnerCharacters.Count;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(totalNumberOfSeconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerCharacters[i]);
            Thread.Sleep(250);

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

    public void DisplayRightLeftBarSpinnerForCountdownTimer(int totalNumberOfSeconds, bool progressiveSpinner = false)
    {
        List<string> spinnerCharacters = new List<string>();

        spinnerCharacters.Add("▉");
        spinnerCharacters.Add("▊");
        spinnerCharacters.Add("▋");
        spinnerCharacters.Add("▌");
        spinnerCharacters.Add("▍");
        spinnerCharacters.Add("▎");
        spinnerCharacters.Add("▏");
        spinnerCharacters.Add("▎");
        spinnerCharacters.Add("▍");
        spinnerCharacters.Add("▌");
        spinnerCharacters.Add("▋");
        spinnerCharacters.Add("▊");
        spinnerCharacters.Add("▉");
        
        int i = 0;
        int c = spinnerCharacters.Count;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(totalNumberOfSeconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerCharacters[i]);
            Thread.Sleep(250);

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

    public void DisplayLevelSpinnerForCountdownTimer(int totalNumberOfSeconds, bool progressiveSpinner = true, bool eraseProgress = true)
    {
        List<string> spinnerCharacters = new List<string>();

        spinnerCharacters.Add("_");
        spinnerCharacters.Add("-");
        spinnerCharacters.Add("¯");
        spinnerCharacters.Add("-");

        int i = 0;
        int c = spinnerCharacters.Count;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(totalNumberOfSeconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerCharacters[i]);
            Thread.Sleep(1000);

            if (eraseProgress)
            {
                if (progressiveSpinner)
                {
                    Console.Write("\b  \b");
                }
                else
                {
                    Console.Write("\b \b");
                }
            }

            i++;

            if (i >= c)
            {
                i = 0;
            }
        }
    }

    public void DisplayShruggingForCountdownTimer(int totalNumberOfSeconds)
    {
        List<string> spinnerCharacters = new List<string>();

        spinnerCharacters.Add("¯\\_(ツ)_/¯");
        spinnerCharacters.Add("¯\\_(ツ)_--");
        spinnerCharacters.Add("¯\\_(ツ)__-");
        spinnerCharacters.Add("¯\\_(ツ)___");
        spinnerCharacters.Add("--_(ツ)___");
        spinnerCharacters.Add("-__(ツ)___");
        spinnerCharacters.Add("___(ツ)___");
        spinnerCharacters.Add("___(\"\")___");
        spinnerCharacters.Add("___(\";)___");
        spinnerCharacters.Add("___(ツ)___");
        spinnerCharacters.Add("___(ツ)_--");
        spinnerCharacters.Add("___(ツ)_/¯");
        spinnerCharacters.Add("--_(ツ)_/¯");
        spinnerCharacters.Add("¯\\_(ツ)_/¯");
        spinnerCharacters.Add("--_(ツ)_--");
        spinnerCharacters.Add("___(ツ)___");
        spinnerCharacters.Add("--_(ツ)_--");

        int i = 0;
        int c = spinnerCharacters.Count;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(totalNumberOfSeconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerCharacters[i]);
            Thread.Sleep(1000);

            Console.Write("\b\b\b\b\b\b\b\b\b        \b\b\b\b\b\b\b\b\b");

            i++;

            if (i >= c)
            {
                i = 0;
            }
        }
    }
}