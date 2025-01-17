using System;

public class PromptOptions
{
    Random random = new Random();

    public List<string> _promptList = new List<string>();

    public void DisplayPromptEditorMenu()
    {

    }

    public void DisplayNumberedPrompts()
    {
        int index = 0;
        string spacer = "";

        foreach (string prompt in _promptList)
        {   
            Console.WriteLine($"{spacer}{index}: {prompt}");
            index += 1;

            if (index > 9)
            {
                spacer = " ";    
            }
        }
    }

    public void DisplayAddPromptMenu()
    {

    }

    public void DisplayDeletePromptMenu()
    {
        
    }

    public void DeletePromptByIndex(int promptIndex)
    {

    }

    public void DisplayPromptIndexOutOfRangeError(int promptIndex)
    {
        
    }

    public void AddNewPrompt(string newPrompt)
    {
        // First, find out if the prompt already exists in the prompt list
        int itemIndex = _promptList.IndexOf(newPrompt);

        if (itemIndex == -1)
        {
            // the new prompt does not exist in the prompt list - add it
            _promptList.Add(newPrompt);
        }
    }

    public string GetPromptByIndex(int promptIndex)
    {
        // make sure that the promptIndex provided is within the range of the promptList
        if (promptIndex > 0 && promptIndex < _promptList.Count)
        {
            return _promptList[promptIndex];
        }
        else
        {
            return GetRandomPrompt();
        }
    }

    public string GetRandomPrompt()
    {
        int randomIndex = random.Next(_promptList.Count);
        return _promptList[randomIndex];
    }

    public void PopulateDefaultPromptList()
    {
        _promptList.Add("If I had one thing I could do over today, what would it be?");
        _promptList.Add("What was the best part of my day?");
        _promptList.Add("What was the kindest thing that someone said to you today?");
        _promptList.Add("What did you learn in your personal scripture study today?");
        _promptList.Add("How did you see the hand of the Lord in your life today?");

    }

    public void LoadPromptList(string filename)
    {

    }

	public void WritePromptList(string filename)
    {

    }
}