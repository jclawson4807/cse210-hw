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
        Console.WriteLine("\n\nGOAL MENU");
        
        if (_globalPointTotal == 1)
        {
            Console.WriteLine("\nYou have 1 point.");
        }
        else
        {
            Console.WriteLine($"\nYou have {_globalPointTotal} points.");
        }

        Console.WriteLine("\nMenu Options:");
        Console.WriteLine("  1. Create New Goal");
        Console.WriteLine("  2. List Goals");
        Console.WriteLine("  3. Save Goals");
        Console.WriteLine("  4. Load Goals");
        Console.WriteLine("  5. Record Event");
        Console.WriteLine("  6. Edit Goal");
        Console.WriteLine("  7. Quit");
        Console.Write("Select a choice from the menu: ");
        
        string menuSelectionString = Console.ReadLine();

        int menuSelectionInt = ExtractIntFromString(menuSelectionString);

        if (menuSelectionInt < 1 || menuSelectionInt > 7)
        {
            Console.WriteLine("You must enter an integer between 1 and 7 inclusive.");
            return DisplayGoalMenu();
        }

        return menuSelectionInt;
    }

    public bool DisplayCreateGoalMenu()
    {
        Console.WriteLine("\n\nCREATE GOAL MENU");

        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Stacked Goal");
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
        else if (menuSelectionInt == 4)
        {
            StackedGoal stackedGoal = new StackedGoal();
            stackedGoal = stackedGoal.DisplayCreateGoalMenu();
            _goalList.Add(stackedGoal);
        }
        else
        {
            Console.WriteLine("You must enter an integer value between 1 and 4 inclusive.");
            return false;    
        }

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
                
                Console.WriteLine("\n\nGOAL LIST");

                Console.WriteLine("\nThe goals are:");

                foreach (Goal goal in _goalList)
                {
                    Console.WriteLine(goal.GetGoalDisplayString());   
                }

                Console.WriteLine("\nPress any key to continue.");
                string userInput = Console.ReadLine();
            }
            else if (actionInt == 3)
            {
                Console.WriteLine("\n\nWRITE GOALS TO FILE");
                
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

                Console.WriteLine($"\nGoals written to {filename}"); 
            }
            else if (actionInt == 4)
            {
                _goalList.Clear();

                Console.WriteLine("\n\nREAD GOALS FROM FILE");
                
                Console.Write("\nWhat is the filename of the goal file? ");  
                string filename = Console.ReadLine();

                if (File.Exists(filename))
                {
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
                            else if (goalType.ToLower() == "stackedgoal")
                            {
                                int originalPoints = ExtractIntFromString(parts[4]);
                                string lastModifiedDateString = parts[5];
                                DateTime lastModifiedDate = DateTime.Parse(lastModifiedDateString);

                                StackedGoal stackedGoal = new StackedGoal(title: title, description: description, originalPoints: originalPoints, currentPoints: points);
                                stackedGoal.SetLastModifiedDate(lastModifiedDate);

                                if (isComplete)
                                {
                                    stackedGoal.SetIsGoalComplete(true);
                                }

                                _goalList.Add(stackedGoal);
                            }
                        }

                        lineNumber++;
                    }

                    Console.WriteLine($"\nGoals read from {filename}");  
                } 
                else
                {
                    Console.WriteLine($"\nFile {filename} not found.");
                }    
            }
            else if (actionInt == 5)
            {
                Console.WriteLine("\n\nRECORD GOAL EVENT");

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
                int selectedGoalNumber = ExtractIntFromString(selectedGoalNumberString) - 1;

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
                Console.WriteLine("\n\nGOAL EDITOR");
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
                    int selectedGoalNumber = ExtractIntFromString(selectedGoalNumberString) - 1;

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
                        else if (goalType == "StackedGoal")
                        {
                            StackedGoal stackedGoal = (StackedGoal)goal;
                            stackedGoal = stackedGoal.DisplayGoalEditor();
                            _goalList[selectedGoalNumber] = stackedGoal;
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
    }
}