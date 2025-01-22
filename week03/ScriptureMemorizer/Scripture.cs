using System;
using System.Text.RegularExpressions;

class Scripture
{
    private ScriptureReference _scriptureReference;

    private List<Word> _wordsList = new List<Word>();

    private string _scriptureText;

    public Scripture(string scriptureReferenceText, string scriptureText)
    {
        SetScripture(scriptureReferenceText, scriptureText);
    }

    private void PopulateWordListForScriptureText(string scriptureText)
    {
        _wordsList.Clear();
        
        string regexPattern = @"[^A-Za-z]";

        string[] tokens = Regex.Split(scriptureText, regexPattern); 
        
        foreach (string token in tokens) 
        {
            bool isWord = true;
            int tokenLength = token.Length;
            string testToken = token.ToLower();

            string trimmedToken = token.Trim();

            Word newWord = new Word(trimmedToken, isWord);

            _wordsList.Add(newWord);
        }
    }

    public void SetScripture(string scriptureReferenceText, string scriptureText)
    {
        ScriptureReference scriptureReference = new ScriptureReference(scriptureReferenceText);

        _scriptureReference = scriptureReference;
        _scriptureText = scriptureText;

        PopulateWordListForScriptureText(scriptureText);
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

    public void HideWords(bool hideHiddenWords)
    {
        Random random = new Random();

        int numberOfWordsToHide = random.Next(1, 3);

        Console.WriteLine();

        for (int i = 0; i < numberOfWordsToHide; i++)
        {
            int randomIndex = random.Next(0, _wordsList.Count);

            Word wordAtIndex = _wordsList[randomIndex];

            if (wordAtIndex.GetIsWord())
            {
                if (hideHiddenWords || wordAtIndex.GetIsHidden() == false)
                {
                    wordAtIndex.SetIsHidden(true);

                    _wordsList[randomIndex] = wordAtIndex;
                }
            }
        }
    }
}