using System;

class Program
{
    static Scripture scripture = new Scripture("3 Nephi 5:13", "Behold, I am a disciple of Jesus Christ, the Son of God. I have been called of him to declare his word among his people, that they might have everlasting life.");

    static void Main(string[] args)
    {
        DisplayScriptureWithMenu();    
    }

    public static void DisplayScriptureWithMenu()
    {
        scripture.DisplayScripture();  

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Press enter to continue or type 'quit' to finish:");

        string readLine = Console.ReadLine();

        if (readLine.Length == 0)
        {
            scripture.HideWords(false);

            DisplayScriptureWithMenu();    
        }
        else
        {
            if (readLine.ToLower().Trim() == "quit")
            {
                Environment.Exit(0);
            }
        }
    }
}