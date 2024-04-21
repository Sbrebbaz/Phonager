using Godot;
using Newtonsoft.Json;
using System;
using System.IO;
using static Constants;

public partial class WallManager : Node, IWallManager
{
	private bool _isInverted = false;
	private float _wallSpeed = DefaultWallSpeed;

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
}