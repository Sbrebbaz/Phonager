using Godot;
using System;

public partial class MainMenuButtons : CanvasLayer
{
	[Signal]
	public delegate void StartGameButtonClickedEventHandler();
	[Signal]
	public delegate void OptionsButtonClickedEventHandler();
	[Signal]
	public delegate void CreditsButtonClickedEventHandler();
	[Signal]
	public delegate void QuitButtonClickedEventHandler();

	private Label _titleLabel;
	private Label _recordLabel;

	private GameManager _gameManager;

	public override void _Ready()
	{
		_gameManager = GetNode<GameManager>("/root/GameManager");

		_titleLabel = GetNode<Label>("MarginContainer/TitleContainer/TitleLabel");
		_titleLabel.LabelSettings.FontColor = Utility.GetRandomColor();

		_recordLabel = GetNode<Label>("MarginContainer/BottomContainer/RecordLabel");
		_recordLabel.Text = $"RECORD: {_gameManager.GetSaveData().Record}";
	}

	public void _on_start_game_button_pressed()
	{
		EmitSignal(SignalName.StartGameButtonClicked);
	}

	public void _on_options_button_pressed()
	{
		
		EmitSignal(SignalName.OptionsButtonClicked);
	}

	public void _on_credits_button_pressed()
	{
		EmitSignal(SignalName.CreditsButtonClicked);
	}

	public void _on_quit_button_pressed()
	{
		EmitSignal(SignalName.QuitButtonClicked);
	}

}
