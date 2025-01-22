using System;

class Word
{
    private string _word;
    private string _hiddenWord = "";
    private int _wordLength;
    private bool _isHidden = false;

    private bool _isWord = true; // I need the be able to store a space or punctuation.  Those can not be made hidden.

    public Word(string word, bool isWord = true)
    {
        _word = word;
        _wordLength = word.Length;

        _isWord = isWord;

        CreateHiddenWord();
    }

    private void CreateHiddenWord()
    {
        _hiddenWord = "";

        if (_isWord)
        {
            for (int i = 0; i < _wordLength; i++)
            {
                _hiddenWord = _hiddenWord + "_";
            }
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
        if (_isWord)
        {
             _isHidden = isHidden;
        }
        else
        {
            _isHidden = false;    
        }
    }

    public bool GetIsHidden()
    {
        return _isHidden;
    }

    public bool GetIsWord()
    {
        return _isWord;
    }

    public void DisplayWord()
    {
        Console.Write($"{GetWord()} ");
    }
}