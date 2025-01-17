using System;
using System.IO;
using System.Text.Json;

public class Journal
{
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

    public void DisplayJournalEditor(int promptIndex)
    {
        // note if promptIndex == -1 display random prompt


    }

    public void DisplayJournalOptionsMenu()
    {
        
    }

    public void AddNewJournalEntry(string prompt, string journalEntryText)
    {
        JournalEntry journalEntry = new JournalEntry();
        journalEntry._prompt = prompt;
        journalEntry._journalEntryText = journalEntryText;
        journalEntry._journalEntryTimeStamp = DateTime.Now;

        _journalEntryList.Add(journalEntry);
    }

    public void LoadPromptList()
    {
        // string jsonText = File.ReadAllText(@"./prompts.json");
        // var promptOptions = JsonSerializer.Deserialize<PromptOptions>(jsonText);

        // _promptOptions = promptOptions;
    }

    public void WritePromptList()
    {
        // string fileName = "prompts.json";
        // string jsonText = JsonSerializer.Serialize(_promptOptions);
        // File.WriteAllText(fileName, jsonText);
    }
}