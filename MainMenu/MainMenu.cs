using Godot;
using System;

public partial class MainMenu : Node2D
{
	private GameManager _gameManager;

	public override void _Ready()
	{
		base._Ready();
		_gameManager = GetNode<GameManager>("/root/GameManager");
	}

	public void _on_main_menu_buttons_start_game_button_clicked()
	{
		_gameManager.LoadScene(Phonager.Enumerators.GameScenes.InGame);
	}

	public void _on_main_menu_buttons_options_button_clicked()
	{
		_gameManager.LoadScene(Phonager.Enumerators.GameScenes.Options);
	}

	public void _on_main_menu_buttons_credits_button_clicked()
	{
		_gameManager.LoadScene(Phonager.Enumerators.GameScenes.Credits);
	}

	public void _on_main_menu_buttons_quit_button_clicked()
	{
		_gameManager.LoadScene(Phonager.Enumerators.GameScenes.Quit);
	}
}
