using System;
using System.Data;

/*
Exceeding Requirements

1) I added support for multiple scriptures
2) When hiding words, only unhidden words are hidden
3) Add menu which allows the user to add a new scripture to study

*/

class Program
{
    static List<Scripture> scriptures = new List<Scripture>();
    static int selectedScriptureIndex = -1;
    static int sleepInMilliseconds = 2000;

    static void Main(string[] args)
    {
        scriptures.Add(new Scripture("3 Nephi", 5, 13, "Behold, I am a disciple of Jesus Christ, the Son of God. I have been called of him to declare his word among his people, that they might have everlasting life."));
        scriptures.Add(new Scripture("2 Nephi", 4, 19, "And when I desire to rejoice, my heart groaneth because of my sins; nevertheless, I know in whom I have trusted."));
        scriptures.Add(new Scripture("Alma", 5, 6, 7, "6 And now behold, I say unto you, my brethren, you that belong to this church, have you sufficiently retained in remembrance the captivity of your fathers? Yea, and have you sufficiently retained in remembrance his mercy and long-suffering towards them? And moreover, have ye sufficiently retained in remembrance that he has delivered their souls from hell? 7 Behold, he changed their hearts; yea, he awakened them out of a deep sleep, and they awoke unto God. Behold, they were in the midst of darkness; nevertheless, their souls were illuminated by the light of the everlasting word; yea, they were encircled about by the bands of death, and the chains of hell, and an everlasting destruction did await them."));

        DisplayScriptureSelector();
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

        Console.Write("\nEnter scripture ID: ");

        string scriptureIDString = Console.ReadLine();

        try
        {
            selectedScriptureIndex = int.Parse(scriptureIDString);
            DisplayScriptureWithMenu(true);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: You must enter an integer value  ({e})");

            Thread.Sleep(sleepInMilliseconds);

            DisplayScriptureSelector();
        }
    }

    public static void DisplayAddScriptureMenu()
    {
        Console.Clear();

        Console.WriteLine("Add Scripture\n");

        try
        {
            Console.Write("\nEnter the name of the book of scripture (such as 1 Nephi): ");

            string bookOfScriptureName = Console.ReadLine();

            Console.Write("\nEnter the chapter number as an integer: ");

            string inputString = Console.ReadLine();

            int chapterNumberInt = int.Parse(inputString);

            Console.Write("\nEnter the starting verse number as an integer: ");

            inputString = Console.ReadLine();

            int startingVerseInt = int.Parse(inputString);

            Console.Write("\nEnter the ending verse number as an integer.  If the scripture text is only one verse long, enter the same number as the starting verse number: ");

            inputString = Console.ReadLine();

            int endingVerseInt = int.Parse(inputString);

            Console.Write("\nEnter the scripture text.  This must be entered as a single line of text. ");

            string scriptureText = Console.ReadLine();

            if (startingVerseInt == endingVerseInt)
            {
                scriptures.Add(new Scripture(bookOfScriptureName, chapterNumberInt, startingVerseInt, scriptureText));    
            }
            else
            {
                scriptures.Add(new Scripture(bookOfScriptureName, chapterNumberInt, startingVerseInt, endingVerseInt, scriptureText));
            }

            DisplayScriptureSelector();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: You must enter an integer value  ({e})");

            Thread.Sleep(sleepInMilliseconds);

            DisplayAddScriptureMenu();
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

        Console.WriteLine("Press enter to continue, 'new' for a new scripture, 'add' to add a scripture, or type 'quit' to finish:");

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
            }
            else if (readLine.ToLower().Trim() == "add")
            {
                DisplayAddScriptureMenu();
            }
            else if (readLine.ToLower().Trim() == "quit")
            {
                Environment.Exit(0);
            }
        }
    }
}