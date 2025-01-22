using System;

class Scripture
{
    private ScriptureReference _scriptureReference;

    private List<Word> _wordsList = new List<Word>();

    private string _scriptureText;

    private void PopulateWordListForScriptureText(string scriptureText)
    {

    }

    public Scripture(ScriptureReference scriptureReference, string scriptureText)
    {
        _scriptureReference = scriptureReference;
        _scriptureText = scriptureText;

        PopulateWordListForScriptureText(scriptureText);
    }

}