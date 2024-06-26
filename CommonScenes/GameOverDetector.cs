using Godot;
using System;
using System.Xml;
using static Enumerators;

public partial class GameOverDetector : Area2D
{
	private GameManager _gameManager;

	public override void _Ready()
	{
		_gameManager = GetNode<GameManager>("/root/GameManager");
	}

	// Called when the node enters the scene tree for the first time.
	public void _on_body_entered(Node2D node)
	{
		if (node is Player)
		{
			_gameManager.EndMatch();
			_gameManager.LoadScene(GameScenes.Menu);
		}
	}
}