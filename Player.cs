using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private const float Speed = 300.0f;
	private AnimatedSprite2D _animatedSprite2D;


	public override void _Ready()
	{
		base._Ready();
		_animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		if (Input.IsActionJustPressed("ui_left"))
		{
			_animatedSprite2D.Play("left");
		}
		if (Input.IsActionJustPressed("ui_right"))
		{
			_animatedSprite2D.Play("right");
		}
		if (Input.IsActionJustPressed("ui_up"))
		{
			_animatedSprite2D.Play("up");
		}
		if (Input.IsActionJustPressed("ui_down"))
		{
			_animatedSprite2D.Play("down");
		}

		if (!Input.IsActionPressed("ui_left") &&
			!Input.IsActionPressed("ui_right") &&
			!Input.IsActionPressed("ui_up") &&
			!Input.IsActionPressed("ui_down"))
		{
			_animatedSprite2D.Pause();
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
