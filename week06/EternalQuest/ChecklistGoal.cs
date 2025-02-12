using System;

public class ChecklistGoal : Goal
{
    private int _numberOfCompletionsNeededForBonus;
    private int _numberOfTimesCompleted;
    private int _bonusPointsAmount;

    public ChecklistGoal() : base ()
    {

    }
    
    public ChecklistGoal(string title, string description, int points, int numberOfCompletionsNeededForBonus, int numberOfTimesCompleted, int bonusPointsAmount) : base(title: title, description: description, points: points)
    {
        _numberOfCompletionsNeededForBonus = numberOfCompletionsNeededForBonus;
        _numberOfTimesCompleted = numberOfTimesCompleted;
        _bonusPointsAmount = bonusPointsAmount;
    }

    public int GetNumberOfCompletionsNeededForBonus()
    {
        return _numberOfCompletionsNeededForBonus;    
    }

    public int GetNumberOfTimesCompleted()
    {
        return _numberOfTimesCompleted;    
    }

    public int GetBonusPointsAmount()
    {
        return _bonusPointsAmount;    
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

        int points = int.Parse(numberOfPointsString);

        Console.Write("\nHow many times does this goal need to be accomplished for a bonus? ");
        string numberOfCompletionsNeededForBonusString = Console.ReadLine();

        int numberOfCompletionsNeededForBonus = int.Parse(numberOfCompletionsNeededForBonusString);

        Console.Write("\nWhat is the bonus for accomplishing this goal that many times? ");
        string bonusPointsAmountString = Console.ReadLine();

        int bonusPointsAmount = int.Parse(bonusPointsAmountString);

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
}