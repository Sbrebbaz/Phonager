using Godot;
using static Constants;

public partial class DroppingWall : CharacterBody2D
{
	private GameManager _gameManager;
	private bool _pointAwarded = false;
	private bool _playerDetected = false;

	public override void _Ready()
	{
		_gameManager = GetNode<GameManager>("/root/GameManager");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		velocity.Y = _gameManager.GetCurrentWallSpeed();

		Velocity = velocity;
		MoveAndSlide();
	}

	private void _on_point_detect_area_body_entered(Node2D body)
	{
		if (!_pointAwarded &&
			body is Player)
		{
			_playerDetected = true;
		}
	}

	private void _on_point_detect_area_body_exited(Node2D body)
	{
		if (!_pointAwarded &&
			_playerDetected &&
			body is Player)
		{
			_pointAwarded = true;
			_gameManager.IncrementPoints();
		}
	}
}