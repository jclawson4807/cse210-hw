using System;

public class ChecklistGoal : Goal
{
    private int _numberOfCompletionsNeededForBonus;
    private int _numberOfTimesCompleted;
    private int _bonusPointsAmount;

    public ChecklistGoal() : base ()
    {
        SetGoalType("ChecklistGoal");
    }
    
    public ChecklistGoal(string title, string description, int points, int numberOfCompletionsNeededForBonus, int numberOfTimesCompleted, int bonusPointsAmount) : base(title: title, description: description, points: points)
    {
        SetGoalType("ChecklistGoal");
        _numberOfCompletionsNeededForBonus = numberOfCompletionsNeededForBonus;
        _numberOfTimesCompleted = numberOfTimesCompleted;
        _bonusPointsAmount = bonusPointsAmount;
    }

    public int GetNumberOfCompletionsNeededForBonus()
    {
        return _numberOfCompletionsNeededForBonus;    
    }

    public void SetNumberOfCompletionsNeededForBonus(int numberOfCompletionsNeededForBonus)
    {
        _numberOfCompletionsNeededForBonus = numberOfCompletionsNeededForBonus;    
    }

    public int GetNumberOfTimesCompleted()
    {
        return _numberOfTimesCompleted;    
    }

    public void SetNumberOfTimesCompleted(int numberOfTimesCompleted)
    {
        _numberOfTimesCompleted = numberOfTimesCompleted;    
    }

    public int GetBonusPointsAmount()
    {
        return _bonusPointsAmount;    
    }

    public void SetBonusPointsAmount(int bonusPointsAmount)
    {
        _bonusPointsAmount = bonusPointsAmount;    
    }

    public int IncrementGoalCompletionTotal(int incrementAmount)
    {
        _numberOfTimesCompleted += incrementAmount;
        IncrementPointTotal(GetPoints());

        if (_numberOfTimesCompleted == _numberOfCompletionsNeededForBonus)
        {
            SetIsGoalComplete(true);
            
            IncrementPointTotal(GetBonusPointsAmount());
        }

        return GetPointTotal();  
    }

    public override int RecordEvent()
    {
        if (GetIsGoalComplete() == true)
        {
            return 0;
        }
        else
        {
            return IncrementGoalCompletionTotal(1); 
        }
    }

    public override ChecklistGoal DisplayCreateGoalMenu()
    {
        Console.Clear();
        Console.Write("What is the name of your goal? ");
        string title = Console.ReadLine();

        Console.Write("\nWhat is a short description of your goal? ");
        string description = Console.ReadLine();

        Console.Write("\nWhat is the amount of points associated with this goal? ");
        string numberOfPointsString = Console.ReadLine();

        int points = ExtractIntFromString(numberOfPointsString);

        Console.Write("\nHow many times does this goal need to be accomplished for a bonus? ");
        string numberOfCompletionsNeededForBonusString = Console.ReadLine();

        int numberOfCompletionsNeededForBonus = ExtractIntFromString(numberOfCompletionsNeededForBonusString);

        Console.Write("\nWhat is the bonus for accomplishing this goal that many times? ");
        string bonusPointsAmountString = Console.ReadLine();

        int bonusPointsAmount = ExtractIntFromString(bonusPointsAmountString);

        ChecklistGoal checklistGoal = new ChecklistGoal(title: title, description: description, points: points, numberOfCompletionsNeededForBonus: numberOfCompletionsNeededForBonus, numberOfTimesCompleted: 0, bonusPointsAmount: bonusPointsAmount);

        return checklistGoal;
    }

    public override string GetStringRepresentation()
    {
        string completionStateString = "false";

        if (GetIsGoalComplete())
        {
            completionStateString = "true";    
        }

        return $"ChecklistGoal:{GetTitle()}^{GetDescription()}^{GetPoints()}^{completionStateString}^{GetNumberOfTimesCompleted()}^{GetNumberOfCompletionsNeededForBonus()}^{GetBonusPointsAmount()}";
    }

    public override string GetGoalDisplayString()
    {
        string goalDisplayString = "[";

        if (GetIsGoalComplete())
        {
            goalDisplayString += "X";    
        }
        else
        {
            goalDisplayString += " ";    
        }

        goalDisplayString = $"{goalDisplayString}] {GetTitle()} ({GetDescription()}) -- Currently completed: {GetNumberOfTimesCompleted()}/{GetNumberOfCompletionsNeededForBonus()}"; 

        return goalDisplayString;
    }

    public override ChecklistGoal DisplayGoalEditor()
    {
        ChecklistGoal newChecklistGoal = new ChecklistGoal();
        
        Console.Write($"\nPlease enter the new Goal name, or hit enter to use the existing value: ({GetTitle()}): ");

        string title = Console.ReadLine();

        if (title.Trim().Length > 0)
        {
            newChecklistGoal.SetTitle(title.Trim());
        }
        else
        {
            newChecklistGoal.SetTitle(GetTitle());     
        }

        Console.Write($"\nPlease enter the new description, or hit enter to use the existing value: ({GetDescription()}): ");

        string description = Console.ReadLine();

        if (description.Trim().Length > 0)
        {
            newChecklistGoal.SetDescription(description.Trim());
        }
        else
        {
            newChecklistGoal.SetDescription(GetDescription());
        }

        if (GetIsGoalComplete())
        {
            newChecklistGoal.SetIsGoalComplete(true);
            newChecklistGoal.SetPoints(GetPoints()); 
            newChecklistGoal.SetNumberOfTimesCompleted(GetNumberOfTimesCompleted());  
            newChecklistGoal.SetNumberOfCompletionsNeededForBonus(GetNumberOfCompletionsNeededForBonus());   
        }
        else
        {
            Console.Write($"\nPlease enter the new point value for this goal, or hit enter to use the existing value: ({GetPoints()}): ");

            string pointsString = Console.ReadLine();

            if (pointsString.Length > 0)
            {
                int points = ExtractIntFromString(pointsString);

                newChecklistGoal.SetPoints(points);
            }
            else
            {
                newChecklistGoal.SetPoints(GetPoints());    
            }

            Console.Write($"\nPlease enter the new number of times does this goal need to be accomplished for a bonus, or hit enter to use the existing value: ({GetNumberOfCompletionsNeededForBonus()}): ");
            string numberOfCompletionsNeededForBonusString = Console.ReadLine();

            if (numberOfCompletionsNeededForBonusString.Length > 0)
            {
                int numberOfCompletionsNeededForBonus = ExtractIntFromString(numberOfCompletionsNeededForBonusString);

                newChecklistGoal.SetNumberOfCompletionsNeededForBonus(numberOfCompletionsNeededForBonus);
            }
            else
            {
                newChecklistGoal.SetNumberOfCompletionsNeededForBonus(GetNumberOfCompletionsNeededForBonus());    
            }

            Console.Write($"\nPlease enter the new bonus for accomplishing this goal that many times, or hit enter to use the existing value: ({GetBonusPointsAmount()}): ");
            string bonusPointsAmountString = Console.ReadLine();

            if (bonusPointsAmountString.Length > 0)
            {
                int bonusPointsAmount = ExtractIntFromString(bonusPointsAmountString);

                newChecklistGoal.SetBonusPointsAmount(bonusPointsAmount);
            }
            else
            {
                newChecklistGoal.SetBonusPointsAmount(GetBonusPointsAmount());    
            }

            newChecklistGoal.SetNumberOfTimesCompleted(GetNumberOfTimesCompleted());
        }

        return newChecklistGoal;
    }
}