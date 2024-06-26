using Godot;
using System;
using static Enumerators;

public partial class MainMenu : Node2D
{
	private GameManager _gameManager;
	private LevelModel _testLevel;

	public override void _Ready()
	{
		base._Ready();
		_gameManager = GetNode<GameManager>("/root/GameManager");
		_testLevel = ResourceLoader.Load<LevelModel>("res://Levels/TestLevel.tres");
	}

	public void _on_main_menu_buttons_start_game_button_clicked()
	{
		_gameManager.LoadScene(GameScenes.InGame);
		_gameManager.StartMatch();

		_gameManager.PlayLevel(_testLevel);
	}

	public void _on_main_menu_buttons_options_button_clicked()
	{
		_gameManager.LoadScene(GameScenes.Options);
	}

	public void _on_main_menu_buttons_credits_button_clicked()
	{
		_gameManager.LoadScene(GameScenes.Credits);
	}

	public void _on_main_menu_buttons_quit_button_clicked()
	{
		_gameManager.LoadScene(GameScenes.Quit);
	}
}
