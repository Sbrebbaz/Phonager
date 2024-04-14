using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class WallGenerator : Node2D
{
	private double _generationInterval = 1;
	private double _currentGenerationInteval = 1;
	private List<PackedScene> _walls = new List<PackedScene>();
	private Node2D _currentLevel;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_currentLevel = GetNode<Node2D>(".");

		_walls.Add(ResourceLoader.Load<PackedScene>("res://CommonScenes/Walls/Wall_1.tscn"));
		_walls.Add(ResourceLoader.Load<PackedScene>("res://CommonScenes/Walls/Wall_2.tscn"));
		_walls.Add(ResourceLoader.Load<PackedScene>("res://CommonScenes/Walls/Wall_3.tscn"));
	}

	private PackedScene GetRandomWall()
	{
		return _walls.OrderBy(x => Guid.NewGuid()).First();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_currentGenerationInteval += delta;
		if (_currentGenerationInteval >= _generationInterval)
		{
			_currentGenerationInteval = 0;
			_generateWall();
		}
	}

	private void _generateWall()
	{
		_currentLevel.AddChild(GetRandomWall().Instantiate());
	}
}
