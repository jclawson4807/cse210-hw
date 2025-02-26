using System;

class Scripture
{
    private ScriptureReference _scriptureReference;

    private List<Word> _wordsList = new List<Word>();
    private List<int> _visibleWordIndexes = new List<int>();

    private string _scriptureText;

    public Scripture(string bookOfScriptureName, int chapterNumber, int verseNumber, string scriptureText)
    {
        _scriptureReference = new ScriptureReference(bookOfScriptureName, chapterNumber, verseNumber);
        _scriptureText = scriptureText;
        
        PopulateWordListForScriptureText(scriptureText);
    }
    public Scripture(string bookOfScriptureName, int chapterNumber, int startVerseNumber, int endVerseNumber, string scriptureText)
    {
        _scriptureReference = new ScriptureReference(bookOfScriptureName, chapterNumber, startVerseNumber, endVerseNumber);
        _scriptureText = scriptureText;

        PopulateWordListForScriptureText(scriptureText);
    }

    private void PopulateWordListForScriptureText(string scriptureText)
    {
        _wordsList.Clear();
        _visibleWordIndexes.Clear();

        int visibleIndex = 0;

        string[] tokens = scriptureText.Split(); 
        
        foreach (string token in tokens) 
        {
            string trimmedToken = token.Trim();

            Word newWord = new Word(trimmedToken);

            _wordsList.Add(newWord);

            _visibleWordIndexes.Add(visibleIndex);

            visibleIndex++;
        }
    }

    public void SetScripture(ScriptureReference scriptureReference, string scriptureText)
    {
        _scriptureReference = scriptureReference;
        _scriptureText = scriptureText;

        PopulateWordListForScriptureText(scriptureText);
    }

    public ScriptureReference GetScriptureReference()
    {
        return _scriptureReference;
    }

    public void DisplayScripture()
    {
        Console.Clear();
        
        _scriptureReference.DisplayScriptureReferenceString();

        foreach (Word word in _wordsList)
        {
            word.DisplayWord();
        }
    }

    public void ResetHiddenWords()
    {
        PopulateWordListForScriptureText(_scriptureText);
    }

    public void HideWords(bool hideHiddenWords)
    {
        Random random = new Random();

        int numberOfWordsToHide = random.Next(1, 3);

        Console.WriteLine();

        if (_visibleWordIndexes.Count > 0)
        {
            for (int i = 0; i < numberOfWordsToHide; i++)
            {
                int randomIndex = random.Next(0, _visibleWordIndexes.Count);

                int index = _visibleWordIndexes[randomIndex];

                Word wordAtIndex = _wordsList[index];

                if (hideHiddenWords || wordAtIndex.GetIsHidden() == false)
                {
                    wordAtIndex.SetIsHidden(true);

                    _wordsList[index] = wordAtIndex;

                    _visibleWordIndexes.RemoveAt(randomIndex);
                }
            }
        }
        else
        {
            Environment.Exit(0);
        }
    }
}