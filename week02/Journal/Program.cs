using System;
using System.Net;

class Program
{
    static int sleepInMilliseconds = 2000;
    static Journal journal = new Journal();
    static PromptOptions promptOptions = new PromptOptions();

    static void Main(string[] args)
    {
        // TODO - try to load prompt options list - if file is not found - populate default list
        promptOptions.PopulateDefaultPromptList();
        DisplayPrimaryMenu();
    }

    static void DisplayPrimaryMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Journal Program\n"); // add a new line before this text - and add an extra new line after the text

        Console.WriteLine("1. Create Journal Entry");
        Console.WriteLine("2. Display Journal Entries - Sort by Date");
        Console.WriteLine("3. Display Journal Entries - Sort by Prompt");
        Console.WriteLine("4. Display Journal Entries - Sort by Journal Entry Text");
        Console.WriteLine("5. Prompt Editor");
        Console.WriteLine("6. Save Journal");
        Console.WriteLine("7. Load Journal");
        Console.WriteLine("8. Quit\n");

        Console.Write("Select a menu option: ");

        string menuOptionString = Console.ReadLine();

        try
        {
            int menuOptionInt = int.Parse(menuOptionString);

            if (menuOptionInt == 1)
            {
                journal.DisplayJournalEditor(-1);   
            }
            else if (menuOptionInt == 2)
            {
                journal.DisplaySortedJournalEntries(1);  
            }
            else if (menuOptionInt == 3)
            {
                journal.DisplaySortedJournalEntries(2);    
            }
            else if (menuOptionInt == 4)
            {
                journal.DisplaySortedJournalEntries(3);   
            }
            else if (menuOptionInt == 5)
            {
                promptOptions.DisplayPromptEditorMenu();   
            }
            else if (menuOptionInt == 6)
            {
                journal.DisplaySaveJournalMenu();   
            }
            else if (menuOptionInt == 7)
            {
                journal.DisplayLoadJournalMenu();   
            }
            else if (menuOptionInt == 8)
            {
                // @TODO Display quit message  
                System.Environment.Exit(1); 
            }
            else
            {
                Console.WriteLine("Error: You must enter an integer value from 1 to 8.");

                Thread.Sleep(sleepInMilliseconds);

                DisplayPrimaryMenu();    
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: You must enter an integer value from 1 to 8.");

            Thread.Sleep(sleepInMilliseconds);

            DisplayPrimaryMenu();
        }
    }
}