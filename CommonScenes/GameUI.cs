using Godot;
using System;

public partial class GameUI : CanvasLayer
{
	private GameManager _gameManager;

	private Label _wallSpeedLabel;
	private Label _playerSpeedLabel;

	private Label _timeLabel;

	private Label _pointLabel;
	private double _time;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_gameManager = GetNode<GameManager>("/root/GameManager");

		_pointLabel = GetNode<Label>("MarginContainer/BoxContainer/TopHorizontalBoxContainer/PointContainer/PointLabel");
		_timeLabel = GetNode<Label>("MarginContainer/BoxContainer/TopHorizontalBoxContainer/TimeContainer/TimeLabel");

		_wallSpeedLabel = GetNode<Label>("MarginContainer/BoxContainer/DifficultyContainer/WallSpeedLabel");
		_playerSpeedLabel = GetNode<Label>("MarginContainer/BoxContainer/DifficultyContainer/PlayerSpeedLabel");

		_time = 0d;
	}

	public override void _Process(double delta)
	{
		_time += delta;

		_timeLabel.Text = TimeSpan.FromSeconds(_time).ToString("mm':'ss':'ffff");

		_pointLabel.Text = _gameManager.GetCurrentPoints().ToString();

		_wallSpeedLabel.Text = $"Current wall speed multiplier: x{_gameManager.GetCurrentDifficultyMultiplier().ToString("#.##")}";
	}
}
