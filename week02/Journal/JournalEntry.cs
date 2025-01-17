using System;

public class JournalEntry
{
    public string _prompt;
    public string _journalEntryText;
    public DateTime _journalEntryTimeStamp;

    public void Display()
    {
        Console.WriteLine($"Date: {_journalEntryTimeStamp.ToShortDateString()} - Prompt: {_prompt}");
        Console.WriteLine(_journalEntryText);
        Console.WriteLine("");
    }
}