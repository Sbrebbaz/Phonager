using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class WallGenerator : Node2D
{
	private List<PackedScene> _walls = new List<PackedScene>();
	private Node2D _currentLevel;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
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

	private void _generateWall()
	{
		_currentLevel.AddChild(GetRandomWall().Instantiate());
	}

}