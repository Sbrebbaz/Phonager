using Godot;
using System;
using static Phonager.Enumerators;

public partial class Player : CharacterBody2D
{
	private const float Speed = 300.0f;
	private AnimatedSprite2D _animatedSprite2D;

	private MovementDirection _currentMovementDirection;


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

		_handlePlayerAnimation();

		Velocity = velocity;
		MoveAndSlide();
	}

	private void _handlePlayerAnimation()
	{
		MovementDirection movementDirection = MovementDirection.idle;
		bool updateAnimation = false;

		if (Input.IsActionJustPressed("ui_left") ||
		   (Input.IsActionPressed("ui_left") &&
		   _animatedSprite2D.Animation != "left"))
		{
			movementDirection = MovementDirection.left;
			updateAnimation=true;
		}
		else if (Input.IsActionJustPressed("ui_right") ||
			(Input.IsActionPressed("ui_right") &&
			_animatedSprite2D.Animation != "right"))
		{
			movementDirection = MovementDirection.right;
			updateAnimation = true;
		}
		else if (Input.IsActionJustPressed("ui_up") ||
			(Input.IsActionPressed("ui_up") &&
			_animatedSprite2D.Animation != "up"))
		{
			movementDirection = MovementDirection.up;
			updateAnimation = true;
		}
		else if (Input.IsActionJustPressed("ui_down") ||
			(Input.IsActionPressed("ui_down") &&
			_animatedSprite2D.Animation != "down"))
		{
			movementDirection = MovementDirection.down;
			updateAnimation = true;
		}
		else if (!Input.IsActionPressed("ui_left") &&
			!Input.IsActionPressed("ui_right") &&
			!Input.IsActionPressed("ui_up") &&
			!Input.IsActionPressed("ui_down"))
		{
			movementDirection = MovementDirection.idle;
			updateAnimation = true;
		}



		if (updateAnimation && 
			_currentMovementDirection != movementDirection)
		{
			_currentMovementDirection = movementDirection;

			switch (movementDirection)
			{
				case MovementDirection.idle:
					{
						_animatedSprite2D.Pause();
						break;
					}
				case MovementDirection.up:
				case MovementDirection.down:
				case MovementDirection.left:
				case MovementDirection.right:
					{
						_animatedSprite2D.Play(movementDirection.ToString());
						break;
					}
			}
		}
	}
}
