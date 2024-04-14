using Godot;
using Phonager;
using System;
using static Phonager.Enumerators;

public partial class GameManager : Node, ISceneManager
{
	private ISceneManager _sceneManager;

	public override void _Ready()
	{
		_sceneManager = GetNode<ISceneManager>("/root/SceneManager");
	}

	public void LoadScene(GameScenes gameSceneToLoad)
	{
		_sceneManager.LoadScene(gameSceneToLoad);
	}

}
