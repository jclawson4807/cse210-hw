using System;

class Program
{
    private static List<Goal> _goalList = new List<Goal>();
    private static int _globalPointTotal = 0;

    public static int IncrementGlobalPointTotal(int incrementAmount)
    {
        _globalPointTotal += incrementAmount;
        return _globalPointTotal;
    }

    public static int DisplayGoalMenu()
    {
        Console.Clear();

        if (_globalPointTotal == 1)
        {
            Console.WriteLine("You have 1 point.");
        }
        else
        {
            Console.WriteLine($"You have {_globalPointTotal} points.");
        }

        Console.WriteLine("\nMenu Options:");
        Console.WriteLine("\t1. Create New Goal");
        Console.WriteLine("\t2. List Goals");
        Console.WriteLine("\t3. Save Goals");
        Console.WriteLine("\t4. Load Goals");
        Console.WriteLine("\t5. Record Event");
        Console.WriteLine("\t6. Quit");
        Console.Write("Select a choice from the menu: ");
        
        try
        {
            string menuSelectionString = Console.ReadLine();

            int menuSelectionInt = int.Parse(menuSelectionString);

            return menuSelectionInt;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: You must enter an integer value between 1 and 6. ({e})");

            Thread.Sleep(2000);

            return DisplayGoalMenu();
        }
    }

    public static void DisplayCreateGoalMenu()
    {
        Console.Clear();

        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("\t1. Simple Goal");
        Console.WriteLine("\t2. Eternal Goal");
        Console.WriteLine("\t3. Checklist Goal");
        Console.Write("Wht type of goal would you like to create? ");
        
        try
        {
            string menuSelectionString = Console.ReadLine();

            int menuSelectionInt = int.Parse(menuSelectionString);

            if (menuSelectionInt == 1)
            {
                SimpleGoal simpleGoal = new SimpleGoal();
                simpleGoal = simpleGoal.DisplayCreateGoalMenu();
                _goalList.Add(simpleGoal);
            }
            else if (menuSelectionInt == 2)
            {
                EternalGoal eternalGoal = new EternalGoal();
                eternalGoal = eternalGoal.DisplayCreateGoalMenu();
                _goalList.Add(eternalGoal);
            }
            else if (menuSelectionInt == 3)
            {
                ChecklistGoal checklistGoal = new ChecklistGoal();
                checklistGoal = checklistGoal.DisplayCreateGoalMenu();
                _goalList.Add(checklistGoal);
            }
            else
            {
                Console.WriteLine("You must enter an integer value between 1 and 3.");    
            }

            DisplayGoalMenu();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: You must enter an integer value between 1 and 3. ({e})");

            Thread.Sleep(2000);

            DisplayCreateGoalMenu();
        }
    }

    static void Main(string[] args)
    {
        bool doContinue = true;

        while (doContinue)
        {
            int actionInt = DisplayGoalMenu();

            if (actionInt == 1)
            {
                DisplayCreateGoalMenu();
            }
            else if (actionInt == 2)
            {
                Console.Clear();
                Console.WriteLine("The goals are:");

                foreach (Goal goal in _goalList)
                {
                    Console.WriteLine(goal.GetGoalDisplayString());  
                }

                Console.WriteLine("\nPress any key to continue.");
                string userInput = Console.ReadLine();
            }
            else if (actionInt == 3)
            {
                Console.WriteLine("Save Goals");      
            }
            else if (actionInt == 4)
            {
                Console.WriteLine("Load Goals");      
            }
            else if (actionInt == 5)
            {
                Console.Clear();
                Console.WriteLine("The goals are:");

                foreach (Goal goal in _goalList)
                {
                    Console.WriteLine(goal.GetGoalDisplayString());  
                }

                int numGoals = _goalList.Count;

                Console.Write("\nWhich goal did you accomplish?");

                string goalNumberString = Console.ReadLine();
                int goalNumber = int.Parse(goalNumberString);

                if (goalNumber < 1 || goalNumber > numGoals)
                {
                    Console.WriteLine("Please pick a valid goal number.");
                }
                else
                {
                    Goal goal = _goalList[goalNumber];

                    if (goal.GetIsGoalComplete())
                    {
                        Console.WriteLine("The selected goal has already been completed.");
                    }
                    else
                    {
                        int pointAward = goal.RecordEvent();
                        IncrementGlobalPointTotal(pointAward);

                        Console.WriteLine($"Congratulations!  You have earned {pointAward} points!");
                        Console.WriteLine($"You now have {_globalPointTotal} points.");

                        _goalList[goalNumber] = goal;
                    }
                }

            }
            else if (actionInt == 6)
            {
                Console.WriteLine("Quitting EternalQuest Program.  Good Bye.");
                System.Environment.Exit(1);    
            } 
        }

        /*
        @TODO - 
        2) create the primary menu
        5) add save and load functionality
            this will require a version of the get goal string that returns a storable version rather than the display version
        6) add custom functionality - add a goal type where the score increases based on how many times it is completed in a given day or how much you exceeded a base amount .... such as drinking water, walking, etc. perhaps a ranking system, something that prevents a goal from being accomplished too many times in a given day, a goal editor
        */

    }
}