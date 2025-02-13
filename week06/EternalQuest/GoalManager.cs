using System;
using System.IO;

class GoalManager
{
    private List<Goal> _goalList = new List<Goal>();
    private int _globalPointTotal = 0;

    public int ExtractIntFromString(string intAsString)
    {
        try
        {
            return int.Parse(intAsString);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: Error parsing ({intAsString})");

            return 0;
        }
    }

    public bool ExtractBoolFromString(string boolAsString)
    {
        boolAsString = boolAsString.ToLower();

        if (boolAsString == "true")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int IncrementGlobalPointTotal(int incrementAmount)
    {
        _globalPointTotal += incrementAmount;
        return _globalPointTotal;
    }

    public int DisplayGoalMenu()
    {
        // Console.Clear();

        if (_globalPointTotal == 1)
        {
            Console.WriteLine("\nYou have 1 point.");
        }
        else
        {
            Console.WriteLine($"\nYou have {_globalPointTotal} points.");
        }

        Console.WriteLine("\n\nMenu Options:");
        Console.WriteLine("\t1. Create New Goal");
        Console.WriteLine("\t2. List Goals");
        Console.WriteLine("\t3. Save Goals");
        Console.WriteLine("\t4. Load Goals");
        Console.WriteLine("\t5. Record Event");
        Console.WriteLine("\t6. Edit Goal");
        Console.WriteLine("\t7. Quit");
        Console.Write("Select a choice from the menu: ");
        
        try
        {
            string menuSelectionString = Console.ReadLine();

            int menuSelectionInt = ExtractIntFromString(menuSelectionString);

            return menuSelectionInt;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: You must enter an integer value between 1 and 6. ({e})");

            Thread.Sleep(2000);

            return DisplayGoalMenu();
        }
    }

    public bool DisplayCreateGoalMenu()
    {
        // Console.Clear();

        Console.WriteLine("\n\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("What type of goal would you like to create? ");
        
        string menuSelectionString = Console.ReadLine();

        int menuSelectionInt = ExtractIntFromString(menuSelectionString);

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
            return false;    
        }

        Thread.Sleep(1000);

        return true;
    }

    public void DisplayPrimaryMenu()
    {
        bool doContinue = true;

        while (doContinue)
        {
            int actionInt = DisplayGoalMenu();

            if (actionInt == 1)
            {
                bool goalCreated = DisplayCreateGoalMenu();

                if (goalCreated)
                {
                    Console.WriteLine("\nGoal Created");
                }
                else
                {
                    Console.WriteLine("\nError creating goal");
                }
            }
            else if (actionInt == 2)
            {
                // Console.Clear();
                Console.WriteLine("\n\nThe goals are:");

                foreach (Goal goal in _goalList)
                {
                    Console.WriteLine(goal.GetGoalDisplayString());   
                }

                Console.WriteLine("\nPress any key to continue.");
                string userInput = Console.ReadLine();
            }
            else if (actionInt == 3)
            {
                Console.Write("\nWhat is the filename of the goal file? ");  
                string filename = Console.ReadLine();

                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                    Console.WriteLine("write current point total");
                    outputFile.WriteLine(_globalPointTotal);

                    foreach (Goal goal in _goalList)
                    {
                        Console.WriteLine(goal.GetStringRepresentation());
                        outputFile.WriteLine(goal.GetStringRepresentation());  
                    }
                }

                Console.Write($"\nGoals written to {filename}"); 
            }
            else if (actionInt == 4)
            {
                _goalList.Clear();
                
                Console.Write("\nWhat is the filename of the goal file? ");  
                string filename = Console.ReadLine();

                string[] lines = System.IO.File.ReadAllLines(filename);

                int lineNumber = 0;

                foreach (string line in lines)
                {
                    if (lineNumber == 0)
                    {
                        _globalPointTotal = ExtractIntFromString(line);
                    }
                    else
                    {
                        string[] parts = line.Split("^");
  
                        string[] goalTypeAndTitleArray = parts[0].Split(":");
                        string goalType = goalTypeAndTitleArray[0];
                        string title = goalTypeAndTitleArray[1];
                        string description = parts[1];
                        int points = ExtractIntFromString(parts[2]);
                        bool isComplete = ExtractBoolFromString(parts[3]);

                        if (goalType.ToLower() == "simplegoal")
                        {
                            SimpleGoal simpleGoal = new SimpleGoal(title: title, description: description, points: points);

                            if (isComplete)
                            {
                                simpleGoal.SetIsGoalComplete(true);
                            }

                            _goalList.Add(simpleGoal);
                        }
                        else if (goalType.ToLower() == "eternalgoal")
                        {
                            EternalGoal eternalGoal = new EternalGoal(title: title, description: description, points: points);

                            _goalList.Add(eternalGoal);
                        }
                        else if (goalType.ToLower() == "checklistgoal")
                        {
                            int numberOfTimesCompleted = ExtractIntFromString(parts[4]);
                            int numberOfCompletionsNeededForBonus = ExtractIntFromString(parts[5]);
                            int bonusPointsAmount = ExtractIntFromString(parts[6]);

                            ChecklistGoal checklistGoal = new ChecklistGoal(title: title, description: description, points: points, numberOfCompletionsNeededForBonus: numberOfCompletionsNeededForBonus, numberOfTimesCompleted: numberOfTimesCompleted, bonusPointsAmount: bonusPointsAmount);

                            if (isComplete)
                            {
                                checklistGoal.SetIsGoalComplete(true);
                            }

                            _goalList.Add(checklistGoal);
                        }
                    }

                    lineNumber++;
                }

                Console.Write($"\nGoals read from {filename}");       
            }
            else if (actionInt == 5)
            {
                // Console.Clear();
                Console.WriteLine("\nThe goals are:");

                int goalNumber = 1;

                foreach (Goal goal in _goalList)
                {
                    Console.WriteLine($"{goalNumber}. {goal.GetGoalDisplayString()}");
                    goalNumber++;  
                }

                int numGoals = _goalList.Count;

                Console.Write("\nWhich goal did you accomplish? ");

                string selectedGoalNumberString = Console.ReadLine();
                int selectedGoalNumber = int.Parse(selectedGoalNumberString) - 1;

                if (selectedGoalNumber < 0 || selectedGoalNumber > numGoals)
                {
                    Console.WriteLine("Please pick a valid goal number.");
                }
                else
                {
                    Goal goal = _goalList[selectedGoalNumber];

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

                        _goalList[selectedGoalNumber] = goal;
                    }
                }

            }
            else if (actionInt == 6)
            {
                Console.WriteLine("\nGOAL EDITOR\n");
                Console.WriteLine("\nThe unfinished goals are:");

                int goalNumber = 1;
                bool hasIncompleteGoals = false;

                foreach (Goal goal in _goalList)
                {
                    if (goal.GetIsGoalComplete() == false)
                    {
                        hasIncompleteGoals = true;
                        Console.WriteLine($"{goalNumber}. {goal.GetGoalDisplayString()}");  
                    }
                    goalNumber++;
                }

                int numGoals = _goalList.Count;

                if (hasIncompleteGoals)
                {
                    Console.Write("\nWhich goal do you want to edit? ");

                    string selectedGoalNumberString = Console.ReadLine();
                    int selectedGoalNumber = int.Parse(selectedGoalNumberString) - 1;

                    if (selectedGoalNumber < 0 || selectedGoalNumber > numGoals)
                    {
                        Console.WriteLine("Please pick a valid goal number.");
                    }
                    else
                    {
                        Goal goal = _goalList[selectedGoalNumber];

                        string goalType = goal.GetGoalType();

                        if (goalType == "SimpleGoal")
                        {
                            SimpleGoal simpleGoal = (SimpleGoal)goal;
                            simpleGoal = simpleGoal.DisplayGoalEditor();
                            _goalList[selectedGoalNumber] = simpleGoal;
                        }
                        else if (goalType == "EternalGoal")
                        {
                            EternalGoal eternalGoal = (EternalGoal)goal;
                            eternalGoal = eternalGoal.DisplayGoalEditor();
                            _goalList[selectedGoalNumber] = eternalGoal;
                        }
                        else if (goalType == "ChecklistGoal")
                        {
                            ChecklistGoal checklistGoal = (ChecklistGoal)goal;
                            checklistGoal = checklistGoal.DisplayGoalEditor();
                            _goalList[selectedGoalNumber] = checklistGoal;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You have no incomplete goals.  You can not edit a completed goal.");
                }
            }
            else if (actionInt == 7)
            {
                Console.WriteLine("Quitting EternalQuest Program.  Good Bye.");
                System.Environment.Exit(1);    
            } 
        }

        /*
        @TODO - 
        4) move all menu functionality from Program.cs to GoalManager class
        5) add save and load functionality
            this will require a version of the get goal string that returns a storable version rather than the display version
        6) add custom functionality - add a goal type where the score increases based on how many times it is completed in a given day or how much you exceeded a base amount .... such as drinking water, walking, etc. perhaps a ranking system, something that prevents a goal from being accomplished too many times in a given day, a goal editor
        */

    }
}