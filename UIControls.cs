using Godot;
using System;

public partial class UIControls : CanvasLayer
{
	private bool _isDragging;
	private Vector2 _startingPoint;
	private int _horizontalDeathZone;
	private int _verticalDeathZone;

	private Label _touchPos;

	public override void _Ready()
	{
		base._Ready();
		_horizontalDeathZone = (int)(GetViewport().GetVisibleRect().Size.X / 5);
		_verticalDeathZone = (int)(GetViewport().GetVisibleRect().Size.Y / 5);

		_touchPos = GetNode<Label>("Label");
		_touchPos.Visible = false;
	}

	public void _on_touch_controls_button_down()
	{
		_movementStart();
	}

	public void _on_touch_controls_button_up()
	{
		_movementEnd();
	}

	public void _on_touch_screen_button_pressed()
	{
		_movementStart();
	}

	public void _on_touch_screen_button_released()
	{
		_movementEnd();
	}

	private void _movementStart()
	{
		if (!_isDragging)
		{
			_startingPoint = GetViewport().GetMousePosition();
			_isDragging = true;
			_touchPos.GlobalPosition = _startingPoint - _touchPos.Size / 2;
			_touchPos.Visible = true;
		}
	}

	private void _movementEnd()
	{
		if (_isDragging)
		{
			_isDragging = false;
			_touchPos.Visible = false;
		}
	}

	private void _resetHorizontalInput()
	{
		Input.ActionRelease("ui_left");
		Input.ActionRelease("ui_right");
	}

	private void _resetVerticalInput()
	{
		Input.ActionRelease("ui_down");
		Input.ActionRelease("ui_up");
	}

	private void _resetInput()
	{
		_resetHorizontalInput();
		_resetVerticalInput();
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);
		if (_isDragging)
		{
			Vector2 currentPosition = GetViewport().GetMousePosition();
			Vector2 movement = currentPosition - _startingPoint;

			if (movement.X > 10)
			{
				Input.ActionPress("ui_right", 1);
			}
			else if (movement.X < -10)
			{
				Input.ActionPress("ui_left", 1);
			}
			else
			{
				_resetHorizontalInput();
			}

			if (movement.Y > 10)
			{
				Input.ActionPress("ui_down", 1);
			}
			else if (movement.Y < -10)
			{
				Input.ActionPress("ui_up", 1);
			}
			else
			{
				_resetVerticalInput();
			}
		}
		else
		{
			_resetInput();
		}
	}
}