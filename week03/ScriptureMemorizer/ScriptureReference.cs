using System;

public class ScriptureReference
{
    private string _bookOfScriptureName; 
    private int _chapterNumber;
    private int _startVerseNumber; 
    private int _endVerseNumber;

    public ScriptureReference(string bookOfScriptureName, int chapterNumber, int verseNumber)
    {
        _bookOfScriptureName = bookOfScriptureName;
        _chapterNumber = chapterNumber;
        _startVerseNumber = verseNumber;
        _endVerseNumber = verseNumber;
    }
    public ScriptureReference(string bookOfScriptureName, int chapterNumber, int startVerseNumber, int endVerseNumber)
    {
        _bookOfScriptureName = bookOfScriptureName;
        _chapterNumber = chapterNumber;
        _startVerseNumber = startVerseNumber;
        _endVerseNumber = endVerseNumber;
    }

    public string GetScriptureReferenceString()
    {
        string scriptureReferenceString = $"{_bookOfScriptureName} {_chapterNumber}: {_startVerseNumber}";

        if (_startVerseNumber != _endVerseNumber)
        {
            scriptureReferenceString += $"-{_endVerseNumber}";    
        }

        return scriptureReferenceString;
    }

    public void DisplayScriptureReferenceString()
    {
        Console.Write($"{GetScriptureReferenceString()} ");
    }

}