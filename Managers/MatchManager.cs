using Godot;

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

	private IPlayerManager _playerManager;
	private IWallManager _wallManager;

	public override void _Ready()
	{
		_playerManager = GetNode<IPlayerManager>("/root/PlayerManager");
		_wallManager = GetNode<IWallManager>("/root/WallManager");
	}

	public void StartMatch()
	{
		ResetPoints();
	}

	public void PlayLevel(LevelModel levelToPlay)
	{
		_playerManager.SetCurrentPlayerSpeed(levelToPlay.PlayerSpeed);
		_wallManager.SetCurrentWallSpeed(levelToPlay.WallSpeed);
	}

	public void EndMatch()
	{
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
}
