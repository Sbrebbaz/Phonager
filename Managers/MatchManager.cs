using Godot;
using Phonager;

public partial class MatchManager : Node, IMatchManager
{
	private int _levelCounter = 0;

	private int _wallsToGenerateCount = 0;

	private int _currentPoints = 0;

	private double _difficultyTime = 10;
	private double _difficultyMultiplierStep = 0.1d;
	private double _baseDifficultyMultiplier = 1;
	private double _currentDifficultyMultiplier = 1;
	private double _maxDifficultyMultiplier = 3;
	private bool _invertWalls = false;

	public override void _Ready()
	{

	}

	public void StartMatch()
	{
		ResetCurrentDifficultyMultiplier();
		ResetPoints();
	}

	public void EndMatch()
	{
		ResetCurrentDifficultyMultiplier();
		ResetPoints();
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
