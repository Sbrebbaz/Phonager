using Godot;
using System;
using static Enumerators;

public partial class GameManager 
	: Node, 
	ISceneManager,
	IMatchManager,
	IPlayerManager,
	IWallManager,
	ISaveManager
{
	private ISceneManager _sceneManager;
	private IMatchManager _matchManager;
	private ISaveManager _saveManager;
	private IPlayerManager _playerManager;
	private IWallManager _wallManager;

	public override void _Ready()
	{
		_sceneManager = GetNode<ISceneManager>("/root/SceneManager");
		_matchManager = GetNode<IMatchManager>("/root/MatchManager");
		_saveManager = GetNode<ISaveManager>("/root/SaveManager");
		_playerManager = GetNode<IPlayerManager>("/root/PlayerManager");
		_wallManager = GetNode<IWallManager>("/root/WallManager");
	}

	#region SceneManager

	public void LoadScene(GameScenes gameSceneToLoad)
	{
		_sceneManager.LoadScene(gameSceneToLoad);
	}

	#endregion

	#region MatchManager

	public void StartMatch()
	{
		_matchManager.StartMatch();
	}

	public void PlayLevel(LevelModel levelToPlay)
	{
		_matchManager.PlayLevel(levelToPlay);
	}

	public void EndMatch()
	{
		if(_matchManager.GetCurrentPoints() > _saveManager.GetSaveData().Record)
		{
			_saveManager.GetSaveData().Record = _matchManager.GetCurrentPoints();
			_saveManager.SaveFile();
		}

		_matchManager.EndMatch();
	}

	#region Points

	public void SetCurrentPoints(int points)
	{
		_matchManager.SetCurrentPoints(points);
	}

	public void IncrementPoints()
	{
		_matchManager.IncrementPoints();
	}

	public int GetCurrentPoints()
	{
		return _matchManager.GetCurrentPoints();
	}

	public void ResetPoints()
	{
		_matchManager.ResetPoints();
	}

	#endregion

	#endregion

	#region SaveManager

	public void LoadFile()
	{
		_saveManager.LoadFile();
	}

	public void SaveFile()
	{
		_saveManager.SaveFile();
	}

	public SaveModel GetSaveData()
	{
		return _saveManager.GetSaveData();
	}

	#endregion

	#region PlayerManager

	public void SetCurrentPlayerSpeed(float speed)
	{
		_playerManager.SetCurrentPlayerSpeed(speed);
	}

	public float GetCurrentPlayerSpeed()
	{
		return _playerManager.GetCurrentPlayerSpeed();
	}

	public void ResetPlayerSpeed()
	{
		_playerManager.ResetPlayerSpeed();
	}

	public void InvertPlayerSpeed()
	{
		_playerManager.InvertPlayerSpeed();
	}

	#endregion

	#region WallManager

	public void SetCurrentWallSpeed(float speed)
	{
		_wallManager.SetCurrentWallSpeed(speed);
	}

	public float GetCurrentWallSpeed()
	{
		return _wallManager.GetCurrentWallSpeed();
	}

	public void ResetWallSpeed()
	{
		_wallManager.ResetWallSpeed();
	}

	public void InvertWallSpeed()
	{
		_wallManager.InvertWallSpeed();
	}

	public void GenerateRandomWall()
	{
		_wallManager.GenerateRandomWall();
	}

	public void RefreshCurrentLevel()
	{
		_wallManager.RefreshCurrentLevel();
	}

	#endregion

}
