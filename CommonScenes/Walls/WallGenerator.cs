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
	private GameManager _gameManager;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_gameManager = GetNode<GameManager>("/root/GameManager");

		_currentLevel = GetNode<Node2D>(".");

		_walls.Add(ResourceLoader.Load<PackedScene>("res://CommonScenes/Walls/WallsToGenerate/Wall_1.tscn"));
		_walls.Add(ResourceLoader.Load<PackedScene>("res://CommonScenes/Walls/WallsToGenerate/Wall_2.tscn"));
		_walls.Add(ResourceLoader.Load<PackedScene>("res://CommonScenes/Walls/WallsToGenerate/Wall_3.tscn"));
		_walls.Add(ResourceLoader.Load<PackedScene>("res://CommonScenes/Walls/WallsToGenerate/Wall_4.tscn"));
		_walls.Add(ResourceLoader.Load<PackedScene>("res://CommonScenes/Walls/WallsToGenerate/Wall_5.tscn"));
		_walls.Add(ResourceLoader.Load<PackedScene>("res://CommonScenes/Walls/WallsToGenerate/Wall_6.tscn"));
		_walls.Add(ResourceLoader.Load<PackedScene>("res://CommonScenes/Walls/WallsToGenerate/Wall_7.tscn"));
		_walls.Add(ResourceLoader.Load<PackedScene>("res://CommonScenes/Walls/WallsToGenerate/Wall_8.tscn"));
		_walls.Add(ResourceLoader.Load<PackedScene>("res://CommonScenes/Walls/WallsToGenerate/Wall_9.tscn"));
		_walls.Add(ResourceLoader.Load<PackedScene>("res://CommonScenes/Walls/WallsToGenerate/Wall_10.tscn"));
		_walls.Add(ResourceLoader.Load<PackedScene>("res://CommonScenes/Walls/WallsToGenerate/Wall_11.tscn"));
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
		Node wallScene = GetRandomWall().Instantiate();
		DroppingWall droppingWall = (DroppingWall)wallScene;

		droppingWall.GivePoint += WallGenerator_GivePoint;
		droppingWall.SpeedMultiplier = (float)_gameManager.GetCurrentDifficultyMultiplier();

		_currentLevel.AddChild(wallScene);
	}

	private void WallGenerator_GivePoint()
	{
		_gameManager.IncrementPoints();
	}
}
