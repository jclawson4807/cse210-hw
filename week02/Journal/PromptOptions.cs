using System;
using System.Net.Security;
using System.IO;
using System.Text.Json;

public class PromptOptions
{
    Random random = new Random();
    int sleepInMilliseconds = 2000;

    public List<string> _promptList = new List<string>();

    string promptFileName = "prompts.json";

    public int DisplayPromptEditorMenu(bool clearConsole = true)
    {
        if (clearConsole)
        {
            Console.Clear();
        }
        else
        {
            Console.WriteLine("");
        }

        Console.WriteLine("Prompt Editor\n"); // add a new line before this text - and add an extra new line after the text

        Console.WriteLine("1. Display prompt list");
        Console.WriteLine("2. Add new prompt");
        Console.WriteLine("3. Delete prompt");
        Console.WriteLine("4. Save prompt list");
        Console.WriteLine("5. Return to menu\n");

        Console.Write("Select a menu option: ");

        string menuOptionString = Console.ReadLine();

        int returnValue = 0;

        try
        {
            int menuOptionInt = int.Parse(menuOptionString);

            if (menuOptionInt == 1)
            {
                DisplayNumberedPrompts();    
            }
            else if (menuOptionInt == 2)
            {
                returnValue = DisplayAddPromptMenu();    
            }
            else if (menuOptionInt == 3)
            {
                returnValue = DisplayDeletePromptMenu();

                return DisplayPromptEditorMenu(true);  
            }
            else if (menuOptionInt == 4)
            {
                WritePromptList();    
            }
            else if (menuOptionInt == 5)
            {
                return 0;   
            }
            else
            {
                Console.WriteLine("Error: You must enter an integer value from 1 to 5.");

                Thread.Sleep(sleepInMilliseconds);

                return DisplayPromptEditorMenu();    
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: You must enter an integer value from 1 to 5.");

            Thread.Sleep(sleepInMilliseconds);

            return DisplayPromptEditorMenu();
        }

        return returnValue;
    }

    public void DisplayNumberedPrompts(bool displayPromptEditorMenu = true)
    {
        Console.Clear();
        Console.WriteLine("Prompts:\n");

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

        if (displayPromptEditorMenu)
        {
            DisplayPromptEditorMenu(false);
        }
    }

    public int DisplayAddPromptMenu()
    {
        Console.Clear();
        Console.WriteLine("Add Prompt\n"); // add a new line before this text - and add an extra new line after the text

        Console.Write("Enter the text of the new prompt: ");
 
        string prompt_response = Console.ReadLine();

        return AddNewPrompt(prompt_response);     
    }

    public int DisplayDeletePromptMenu()
    {
        Console.Clear();

        Console.WriteLine("Delete Prompt\n"); // add a new line before this text - and add an extra new line after the text

        DisplayNumberedPrompts(false);

        Console.Write("\nEnter the number of the prompt you wish to delete: ");
 
        string promptNumberString = Console.ReadLine();

        try
        {
            int promptIndex = int.Parse(promptNumberString);

            return DeletePromptByIndex(promptIndex);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: You must enter a valid integer.");

            Thread.Sleep(sleepInMilliseconds);

            return DisplayDeletePromptMenu();
        }
    }

    public int DeletePromptByIndex(int promptIndex)
    {
        // make sure that the promptIndex provided is within the range of the promptList
        if (promptIndex > 0 && promptIndex < _promptList.Count)
        {
            _promptList.RemoveAt(promptIndex);

            Console.WriteLine($"\nPrompt at index {promptIndex} removed.");
            
            Thread.Sleep(sleepInMilliseconds);

            return 0;
        }
        else
        {
            return DisplayPromptIndexOutOfRangeError(promptIndex);
        }         
    }

    public int DisplayPromptIndexOutOfRangeError(int promptIndex)
    {
        Console.WriteLine($"Error: Index {promptIndex} is out of bounds.");
        Thread.Sleep(sleepInMilliseconds);

        return 1;    
    }

    public int AddNewPrompt(string newPrompt)
    {
        // First, find out if the prompt already exists in the prompt list
        int itemIndex = _promptList.IndexOf(newPrompt);

        if (itemIndex == -1)
        {
            // the new prompt does not exist in the prompt list - add it
            _promptList.Add(newPrompt);

            Console.WriteLine("\nNew Prompt Added.\n");

            Thread.Sleep(sleepInMilliseconds);

            return DisplayPromptEditorMenu();
        }
        else
        {
            Console.WriteLine("\nThat prompt text is already in the prompt list.  Please try again.\n");

            Thread.Sleep(sleepInMilliseconds);

            return DisplayAddPromptMenu();
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

    public void LoadPromptList()
    {
        string loadedPersonFile = File.ReadAllText(promptFileName);

        Console.WriteLine(loadedPersonFile);

        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        var promptList = JsonSerializer.Deserialize<List<string>>(loadedPersonFile,  options);

        _promptList = promptList;

        Console.WriteLine("\nPrompt data read from file.\n");

        Thread.Sleep(sleepInMilliseconds);

        DisplayPromptEditorMenu();
    }

	public async void WritePromptList()
    {
        // JSON write code from https://code-maze.com/introduction-system-text-json-examples/

        using var stream = File.Create(promptFileName);
        await JsonSerializer.SerializeAsync(stream, _promptList);
        await stream.DisposeAsync();

        Console.WriteLine("\nPrompt data written to file.\n");

        Thread.Sleep(sleepInMilliseconds);

        DisplayPromptEditorMenu();
    }
}