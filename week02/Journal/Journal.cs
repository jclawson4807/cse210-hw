using System;
using System.IO;
using System.Text.Json;

public class Journal
{

    int sleepInMilliseconds = 2000;
    public List<JournalEntry> _journalEntryList = new List<JournalEntry>();

    public void DisplaySaveJournalMenu()
    {

    }

    public void DisplayLoadJournalMenu()
    {
        
    }

    public void SaveJournal(string filename)
    {
        
    }

    public void LoadJournal(string filename)
    {
        
    }

    public void DisplaySortedJournalEntries(int sort_type)
    {
        // if sort type == 0 - do not sort
        // if sort type == 1 - sort by date
        // if sort type == 2 - sort by prompt
        // if sort type == 3 - sort by journal entry text
        // @TODO - include link to C# code to sort list by class member

        foreach (JournalEntry journalEntry in _journalEntryList)
        {
            journalEntry.Display();
            Console.WriteLine("");
        }
    }

    public void DisplayJournalEditor(string prompt, PromptOptions promptOptions)
    {
        Console.Clear();
        Console.WriteLine("Create a Journal Entry\n"); // add a new line before this text - and add an extra new line after the text

        Console.WriteLine(prompt);
        Console.Write("> ");
 
        string prompt_response = Console.ReadLine();

        DisplayJournalOptionsMenu(prompt, prompt_response, promptOptions);
    }

    public void DisplayJournalOptionsMenu(string prompt, string prompt_response, PromptOptions promptOptions)
    {
        Console.WriteLine("\nJournal Editor\n"); // add a new line before this text - and add an extra new line after the text

        Console.WriteLine("1. Keep Journal Entry");
        Console.WriteLine("2. New Prompt");
        Console.WriteLine("3. New Entry With The Same Prompt");
        Console.WriteLine("4. Return to menu\n");

        Console.Write("Select a menu option: ");

        string menuOptionString = Console.ReadLine();

        try
        {
            int menuOptionInt = int.Parse(menuOptionString);

            if (menuOptionInt == 1)
            {
                AddNewJournalEntry(prompt, prompt_response);
            }
            else if (menuOptionInt == 2)
            {
                DisplayJournalEditor(promptOptions.GetRandomPrompt(), promptOptions);    
            }
            else if (menuOptionInt == 3)
            {
                DisplayJournalEditor(prompt, promptOptions);    
            }
            else if (menuOptionInt == 4)
            {
                // @TASK - figure out how to call parent class and call primary display      
            }
            else
            {
                Console.WriteLine("Error: You must enter an integer value from 1 to 4.");

                Thread.Sleep(sleepInMilliseconds);

                DisplayJournalOptionsMenu(prompt, prompt_response, promptOptions);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: You must enter an integer value from 1 to 5.");

            Thread.Sleep(sleepInMilliseconds);

            DisplayJournalOptionsMenu(prompt, prompt_response, promptOptions);
        }
    }

    public void AddNewJournalEntry(string prompt, string journalEntryText)
    {
        JournalEntry journalEntry = new JournalEntry();
        journalEntry._prompt = prompt;
        journalEntry._journalEntryText = journalEntryText;
        journalEntry._journalEntryTimeStamp = DateTime.Now;

        _journalEntryList.Add(journalEntry);
    }
}