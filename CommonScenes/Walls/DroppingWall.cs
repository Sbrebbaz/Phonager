using Godot;

public partial class DroppingWall : CharacterBody2D
{
	[Signal]
	public delegate void GivePointEventHandler();

	private float _speed = 100;

	private float _speedMultiplier = 1;

	public float SpeedMultiplier
	{
		get { return _speedMultiplier; }
		set { _speedMultiplier = value; }
	}

	private bool _pointAwarded = false;
	private bool _playerDetected = false;

	public override void _Ready()
	{
		_pointAwarded = false;
		_speed = 100;
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		velocity.Y = _speed * _speedMultiplier;

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
			EmitSignal(SignalName.GivePoint);
		}
	}

}
