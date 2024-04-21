using Godot;
using Newtonsoft.Json;
using System;
using System.IO;
using static Constants;

public partial class PlayerManager : Node, IPlayerManager
{
	private bool _isInverted = false;
	private float _playerSpeed = DefaultPlayerSpeed;

	public void SetCurrentPlayerSpeed(float speed)
	{
		_playerSpeed = speed;
	}

	public float GetCurrentPlayerSpeed()
	{
		return _playerSpeed;
	}

	public void ResetPlayerSpeed()
	{
		_playerSpeed = DefaultPlayerSpeed;
	}

	public void InvertPlayerSpeed()
	{
		_isInverted = !_isInverted;
	}
}