using System;

public class PromptOptions
{
    public List<string> _promptList = new List<string>();

    public void DisplayPromptEditorMenu()
    {

    }

    public void DisplayNumberedPrompts()
    {
        foreach (string prompt in _promptList)
        {
            Console.WriteLine(prompt);
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
        return "";
    }

    public string GetRandomPrompt()
    {
        return "";
    }

    public void PopulateDefaultPromptList()
    {

    }

    public void LoadPromptList(string filename)
    {

    }
    
	public void WritePromptList(string filename)
    {

    }
}