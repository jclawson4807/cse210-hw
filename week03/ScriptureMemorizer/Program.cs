using System;
using System.Data;

class Program
{
    static List<Scripture> scriptures = new List<Scripture>();
    static int selectedScriptureIndex = -1;
    static int sleepInMilliseconds = 2000;

    static void Main(string[] args)
    {
        scriptures.Add(new Scripture("3 Nephi 5:13", "Behold, I am a disciple of Jesus Christ, the Son of God. I have been called of him to declare his word among his people, that they might have everlasting life."));
        scriptures.Add(new Scripture("2 Nephi 4:19", "And when I desire to rejoice, my heart groaneth because of my sins; nevertheless, I know in whom I have trusted."));
        scriptures.Add(new Scripture("Alma", 5, 6, 7, "6 And now behold, I say unto you, my brethren, you that belong to this church, have you sufficiently retained in remembrance the captivity of your fathers? Yea, and have you sufficiently retained in remembrance his mercy and long-suffering towards them? And moreover, have ye sufficiently retained in remembrance that he has delivered their souls from hell? 7 Behold, he changed their hearts; yea, he awakened them out of a deep sleep, and they awoke unto God. Behold, they were in the midst of darkness; nevertheless, their souls were illuminated by the light of the everlasting word; yea, they were encircled about by the bands of death, and the chains of hell, and an everlasting destruction did await them."));

        DisplayScriptureSelector();

        DisplayScriptureWithMenu(true);
    }

    public static void DisplayScriptureSelector()
    {
        Console.Clear();

        Console.WriteLine("Scripture Selector\n");

        int index = 0;

        foreach (Scripture scripture in scriptures)
        {
            Console.WriteLine($"{index} {scripture.GetScriptureReference().GetScriptureReferenceString()}");
            index++;
        }

        Console.Write("\nEnter scriputure ID: ");

        string scriptureIDString = Console.ReadLine();

        try
        {
            selectedScriptureIndex = int.Parse(scriptureIDString);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: You must enter an integer value  ({e})");

            Thread.Sleep(sleepInMilliseconds);

            DisplayScriptureSelector();
        }
    }

    public static void DisplayScriptureWithMenu(bool resetHiddenWords = false)
    {
        Scripture scripture = scriptures[selectedScriptureIndex];

        if (resetHiddenWords)
        {
            scripture.ResetHiddenWords();
        }
        
        scripture.DisplayScripture();  

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Press enter to continue, 'new' for a new scripture, or type 'quit' to finish:");

        string readLine = Console.ReadLine();

        if (readLine.Length == 0)
        {
            scripture.HideWords(false);

            DisplayScriptureWithMenu();    
        }
        else
        {
            if (readLine.ToLower().Trim() == "new")
            {
                DisplayScriptureSelector();
                DisplayScriptureWithMenu(true);
            }
            else if (readLine.ToLower().Trim() == "quit")
            {
                Environment.Exit(0);
            }
        }
    }
}