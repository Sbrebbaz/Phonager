using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using static Enumerators;

public partial class SceneManager : Node, ISceneManager
{
	public Dictionary<GameScenes, PackedScene> _availableScenes;

	public override void _Ready()
	{
		_availableScenes = new Dictionary<GameScenes, PackedScene>();

		_availableScenes.Add(
			GameScenes.Menu,
			ResourceLoader.Load<PackedScene>("res://MainMenu/MainMenu.tscn")
			);
		_availableScenes.Add(
		GameScenes.Options,
			ResourceLoader.Load<PackedScene>("res://OptionsMenu/OptionsMenu.tscn")
			);
		_availableScenes.Add(
			GameScenes.Credits,
			ResourceLoader.Load<PackedScene>("res://CreditsMenu/CreditsMenu.tscn")
			);
		_availableScenes.Add(
			GameScenes.InGame,
			ResourceLoader.Load<PackedScene>("res://MainGame/MainGame.tscn")
			);

		//TODO IMPLEMENT SCENES BELOW
		//_availableScenes.Add(
		//	GameScenes.CharacterSelect,
		//	ResourceLoader.Load<PackedScene>("res://MainGame/MainGame.tscn")
		//	);
		//_availableScenes.Add(
		//	GameScenes.GameOver,
		//	ResourceLoader.Load<PackedScene>("res://MainGame/MainGame.tscn")
		//	);
		//_availableScenes.Add(
		//	GameScenes.HighScores,
		//	ResourceLoader.Load<PackedScene>("res://MainGame/MainGame.tscn")
		//	);
		//_availableScenes.Add(
		//	GameScenes.Quit,
		//	ResourceLoader.Load<PackedScene>("res://MainGame/MainGame.tscn")
		//	);

	}

	public void LoadScene(GameScenes sceneToLoad)
	{
		switch (sceneToLoad)
		{
			case GameScenes.Menu:
			case GameScenes.Options:
			case GameScenes.CharacterSelect:
			case GameScenes.Credits:
			case GameScenes.InGame:
			case GameScenes.GameOver:
			case GameScenes.HighScores:
				{
					PackedScene packedScene = _availableScenes.FirstOrDefault(ps => ps.Key == sceneToLoad).Value;
					if (packedScene != null)
					{
						GetTree().ChangeSceneToPacked(packedScene);
					}
					else
					{
						GD.PrintErr($"COULD NOT LOAD THE SCENE : {sceneToLoad}");
					}
					break;
				}
			default:
			case GameScenes.Quit:
				{
					GetTree().Quit();
					break;
				}
		}
	}
}
