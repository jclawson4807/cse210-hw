using System;

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
        
        string[] tokens = scriptureText.Split(new char[] { ' ', ',', '?', '.', '!' });
        
        foreach (string token in tokens) {
            bool isWord = false;
            int tokenLength = token.Length;
            string testToken = token.ToLower();

            if (tokenLength > 1 || (testToken == "a" || testToken == "i" || testToken == "a"))
            {
                isWord = true;
            }

            Word newWord = new Word(token,isWord);

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

}