using Godot;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Constants;

public partial class WallManager : Node, IWallManager
{
	private bool _isInverted = false;
	private float _wallSpeed = DefaultWallSpeed;

	private Node _currentLevel;
	private List<PackedScene> _walls = new List<PackedScene>();

	public override void _Ready()
	{
		base._Ready();

		_initializeWalls();
	}

	public void SetCurrentWallSpeed(float speed)
	{
		_wallSpeed = speed;
	}

	public float GetCurrentWallSpeed()
	{
		return _wallSpeed;
	}

	public void ResetWallSpeed()
	{
		_wallSpeed = DefaultWallSpeed;
	}

	public void InvertWallSpeed()
	{
		_isInverted = !_isInverted;
	}

	public void GenerateRandomWall()
	{
		if (_currentLevel != null)
		{
		_currentLevel.AddChild(_getRandomWall().Instantiate());
		}
	}

	public void RefreshCurrentLevel()
	{
		_currentLevel = GetParent().GetNode("MainGame/Walls");
	}

	private void _initializeWalls()
	{
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

	private PackedScene _getRandomWall()
	{
		return _walls.OrderBy(x => Guid.NewGuid()).First();
	}
}