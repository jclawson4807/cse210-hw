using System;

// [Serializable]
public class JournalEntry
{
    public string _prompt { get; set; } = "";
    public string _journalEntryText { get; set; } = "";
    public DateTime _journalEntryTimeStamp { get; set; } = DateTime.Now;

    public void Display()
    {
        Console.WriteLine($"Date: {_journalEntryTimeStamp.ToShortDateString()} - Prompt: {_prompt}");
        Console.WriteLine(_journalEntryText);
        Console.WriteLine("");
    }
}