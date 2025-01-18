using System;
using System.IO;
using System.Text.Json;

public class Journal
{

    int sleepInMilliseconds = 2000;
    public List<JournalEntry> _journalEntryList = new List<JournalEntry>();

    public int DisplaySaveJournalMenu()
    {
        Console.Clear();
        Console.WriteLine("Save Journal\n"); // add a new line before this text - and add an extra new line after the text

        Console.Write("Enter the filename to be used: ");
 
        string prompt_response = Console.ReadLine();

        return SaveJournal(prompt_response);
    }

    public int DisplayLoadJournalMenu()
    {
        Console.Clear();
        Console.WriteLine("Load Journal\n"); // add a new line before this text - and add an extra new line after the text

        Console.Write("Enter the filename of the saved journal file: ");
 
        string prompt_response = Console.ReadLine();

        return LoadJournal(prompt_response);
    }

    public int SaveJournal(string filename)
    {
        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);

        string jsonSerializedJournal = JsonSerializer.Serialize(_journalEntryList, options);

        Console.WriteLine(jsonSerializedJournal);

        File.WriteAllText(filename, jsonSerializedJournal);

        Console.WriteLine("\nJournal data written to file.\n");

        Thread.Sleep(sleepInMilliseconds);

        return 0;    
    }

    public int LoadJournal(string filename)
    {
        if (File.Exists(filename))
        {
            string loadedJournalJsonString = File.ReadAllText(filename);

            Console.WriteLine(loadedJournalJsonString);

            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            var journalData = JsonSerializer.Deserialize<List<JournalEntry>>(loadedJournalJsonString, options);

            _journalEntryList = journalData;

            Console.WriteLine("Loaded Journal Data");

            Thread.Sleep(sleepInMilliseconds);

            return 0;
        }
        else
        {
            Console.WriteLine($"\nError: No file found for filename {filename}.");

            Thread.Sleep(sleepInMilliseconds);

            return DisplayLoadJournalMenu();
        }    
    }

    public void DisplaySortedJournalEntries(int sortType)
    {
        // if sort type == 0 - do not sort
        // if sort type == 1 - sort by date
        // if sort type == 2 - sort by prompt
        // if sort type == 3 - sort by journal entry text

        List<JournalEntry> sortedJournalList = _journalEntryList;

        if (sortType == 1)
        {
            sortedJournalList = _journalEntryList.OrderBy(x => x._journalEntryTimeStamp).ToList();
        }
        else if (sortType == 2)
        {
            sortedJournalList = _journalEntryList.OrderBy(x => x._prompt).ToList();
        }
        else if (sortType == 3)
        {
            sortedJournalList = _journalEntryList.OrderBy(x => x._journalEntryText).ToList();
        }

        foreach (JournalEntry journalEntry in sortedJournalList)
        {
            journalEntry.Display();
            Console.WriteLine("");
        }

        Console.WriteLine("Press enter to return to the menu.");
        string returnText = Console.ReadLine();
    }

    public int DisplayJournalEditor(string prompt, PromptOptions promptOptions)
    {
        Console.Clear();
        Console.WriteLine("Create a Journal Entry\n"); // add a new line before this text - and add an extra new line after the text

        Console.WriteLine(prompt);
        Console.Write("> ");
 
        string prompt_response = Console.ReadLine();

        return DisplayJournalOptionsMenu(prompt, prompt_response, promptOptions);
    }

    public int DisplayJournalOptionsMenu(string prompt, string prompt_response, PromptOptions promptOptions)
    {
        Console.WriteLine("\nJournal Editor\n"); // add a new line before this text - and add an extra new line after the text

        Console.WriteLine("1. Keep Journal Entry");
        Console.WriteLine("2. New Prompt");
        Console.WriteLine("3. New Entry With The Same Prompt");
        Console.WriteLine("4. Save Journal");
        Console.WriteLine("5. Load Journal");
        Console.WriteLine("6. Return to menu\n");

        Console.Write("Select a menu option: ");

        string menuOptionString = Console.ReadLine();

        try
        {
            int menuOptionInt = int.Parse(menuOptionString);

            if (menuOptionInt == 1)
            {
                int response = AddNewJournalEntry(prompt, prompt_response);

                if (response == 1)
                {
                    DisplayJournalOptionsMenu(prompt, prompt_response, promptOptions);    
                }
                else
                {
                    return response;
                }
            }
            else if (menuOptionInt == 2)
            {
                return DisplayJournalEditor(promptOptions.GetRandomPrompt(), promptOptions);    
            }
            else if (menuOptionInt == 3)
            {
                return DisplayJournalEditor(prompt, promptOptions);    
            }
            else if (menuOptionInt == 4)
            {
                return DisplaySaveJournalMenu();    
            }
            else if (menuOptionInt == 5)
            {
                return DisplayLoadJournalMenu();   
            }
            else if (menuOptionInt == 6)
            {
                return 0;  
            }
            else
            {
                Console.WriteLine("Error: You must enter an integer value from 1 to 6.");

                Thread.Sleep(sleepInMilliseconds);

                return DisplayJournalOptionsMenu(prompt, prompt_response, promptOptions);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: You must enter an integer value from 1 to 6.");

            Thread.Sleep(sleepInMilliseconds);

            return DisplayJournalOptionsMenu(prompt, prompt_response, promptOptions);
        }

        return 0;
    }

    public int AddNewJournalEntry(string prompt, string journalEntryText)
    {
        JournalEntry journalEntry = new JournalEntry();
        journalEntry._prompt = prompt;
        journalEntry._journalEntryText = journalEntryText;
        journalEntry._journalEntryTimeStamp = DateTime.Now;

        _journalEntryList.Add(journalEntry);

        return 1;
    }
}