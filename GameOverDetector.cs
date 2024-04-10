using Godot;
using System;
using System.Xml;

public partial class GameOverDetector : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public void _on_body_entered(Node2D node)
	{
		if (node is Player) GetTree().Quit();
	}
}
