using Godot;

public partial class MatchManager : Node, IMatchManager
{
	private IPlayerManager _playerManager;
	private IWallManager _wallManager;
	private int _currentPoints = 0;

	public override void _Ready()
	{
		_playerManager = GetNode<IPlayerManager>("/root/PlayerManager");
		_wallManager = GetNode<IWallManager>("/root/WallManager");
	}

	public void StartMatch()
	{
		ResetPoints();

		_wallManager.RefreshCurrentLevel();
		_wallManager.GenerateRandomWall();
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
