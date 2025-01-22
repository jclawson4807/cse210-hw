using System;

public class ScriptureReference
{
    private string _scriptureReferenceString;

    public ScriptureReference(string scriptureReferenceString)
    {
        _scriptureReferenceString = scriptureReferenceString;
    }

    public string GetScriptureReferenceString()
    {
        return _scriptureReferenceString;
    }

    public void SetScriptureReferenceString(string scriptureReferenceString)
    {
        _scriptureReferenceString = scriptureReferenceString;
    }

    public void DisplayScriptureReferenceString()
    {
        Console.Write($"{_scriptureReferenceString} ");
    }

}