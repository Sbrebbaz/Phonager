using Godot;
using Phonager;
using System;
using static Phonager.Enumerators;

public partial class GameManager 
	: Node, 
	ISceneManager,
	IMatchManager,
	ISaveManager
{
	private ISceneManager _sceneManager;
	private IMatchManager _matchManager;
	private ISaveManager _saveManager;

	public override void _Ready()
	{
		_sceneManager = GetNode<ISceneManager>("/root/SceneManager");
		_matchManager = GetNode<IMatchManager>("/root/MatchManager");
		_saveManager = GetNode<ISaveManager>("/root/SaveManager");
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

	#region Difficulty

	public void SetCurrentDifficultyMultiplier(double difficultyMultiplier)
	{
		_matchManager.SetCurrentDifficultyMultiplier(difficultyMultiplier);
	}

	public void IncrementDifficultyMultiplier()
	{
		_matchManager.IncrementDifficultyMultiplier();
	}

	public void ResetCurrentDifficultyMultiplier()
	{
		_matchManager.ResetCurrentDifficultyMultiplier();
	}

	public double GetCurrentDifficultyMultiplier()
	{
		return _matchManager.GetCurrentDifficultyMultiplier();
	}

	public void InvertDifficulty()
	{
		_matchManager.InvertDifficulty();
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
}
