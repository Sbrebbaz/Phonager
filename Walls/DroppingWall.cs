using Godot;

public partial class DroppingWall : CharacterBody2D
{
	private float _speed = 100;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		velocity.Y = _speed;

		Velocity = velocity;
		MoveAndSlide();
	}
}
