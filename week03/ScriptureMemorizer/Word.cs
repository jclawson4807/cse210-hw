using System;

class Word
{
    private string _word;
    private string _hiddenWord = "";
    private int _wordLength;
    private bool _isHidden = false;
    public Word(string word)
    {
        _word = word;
        _wordLength = word.Length;

        CreateHiddenWord();
    }

    private void CreateHiddenWord()
    {
        _hiddenWord = "";

        for (int i = 0; i < _wordLength; i++)
        {
            _hiddenWord += "_";
        }
    }

    public string GetWord()
    {
        if (_isHidden)
        {
            return _hiddenWord; 
        }
        else
        {
            return _word;
        }
    }

    public void SetIsHidden(bool isHidden)
    {
        _isHidden = isHidden;
    }

    public bool GetIsHidden()
    {
        return _isHidden;
    }

    public void DisplayWord()
    {
        Console.Write($"{GetWord()} ");
    }
}