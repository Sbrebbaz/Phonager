using Godot;
using Phonager;

public partial class MatchManager : Node, IMatchManager
{
	private int _currentPoints = 0;

	private double _difficultyTime = 10;
	private double _difficultyMultiplierStep = 0.1d;
	private double _baseDifficultyMultiplier = 1;
	private double _currentDifficultyMultiplier = 1;
	private double _maxDifficultyMultiplier = 3;
	private bool _invertWalls = false;

	private Timer _matchTimer;

	public override void _Ready()
	{
		_matchTimer = new Timer();

		GetNode<MatchManager>(".").AddChild(_matchTimer);

		_matchTimer.WaitTime = _difficultyTime;
		_matchTimer.Timeout += _matchTimer_Timeout;
	}

	private void _matchTimer_Timeout()
	{
		IncrementDifficultyMultiplier();
	}

	public void StartMatch()
	{
		ResetCurrentDifficultyMultiplier();
		ResetPoints();
		_matchTimer.Stop();
		_matchTimer.Start();
	}

	public void EndMatch()
	{
		ResetCurrentDifficultyMultiplier();
		ResetPoints();
		_matchTimer.Stop();
	}

	#region Points

	public int GetCurrentPoints()
	{
		return _currentPoints;
	}

	public void IncrementPoints()
	{
		_currentPoints++;
	}

	public void ResetPoints()
	{
		_currentPoints = 0;
	}

	public void SetCurrentPoints(int points)
	{
		_currentPoints = points;
	}

	#endregion

	#region DifficultyMultiplier

	public void SetCurrentDifficultyMultiplier(double difficultyMultiplier)
	{
		_currentDifficultyMultiplier = difficultyMultiplier;
	}

	public void IncrementDifficultyMultiplier()
	{
		_currentDifficultyMultiplier += _difficultyMultiplierStep;
		if (_currentDifficultyMultiplier > _maxDifficultyMultiplier)
		{
			_currentDifficultyMultiplier = _maxDifficultyMultiplier;
		}
	}

	public void ResetCurrentDifficultyMultiplier()
	{
		_currentDifficultyMultiplier = _baseDifficultyMultiplier;
	}

	public double GetCurrentDifficultyMultiplier()
	{
		return _invertWalls ? -_currentDifficultyMultiplier : _currentDifficultyMultiplier;
	}

	public void InvertDifficulty()
	{
		_invertWalls = !_invertWalls;
	}

	#endregion

}
