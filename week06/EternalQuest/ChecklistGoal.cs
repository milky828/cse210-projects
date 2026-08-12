public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _targetAmount;
    private int _bonus;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int targetAmount,
        int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _targetAmount = targetAmount;
        _bonus = bonus;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _targetAmount;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }

        _amountCompleted++;

        int pointsEarned = GetPoints();

        if (_amountCompleted == _targetAmount)
        {
            pointsEarned += _bonus;
        }

        return pointsEarned;
    }

    public void SetAmountCompleted(int amountCompleted)
    {
        _amountCompleted = amountCompleted;
    }

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";

        return $"{checkbox} {GetName()} ({GetDescription()}) -- Completed {_amountCompleted}/{_targetAmount} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_targetAmount}|{_bonus}|{_amountCompleted}";
    }
}