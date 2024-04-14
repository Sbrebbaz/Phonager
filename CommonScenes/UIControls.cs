using Godot;
using System;
using System.Diagnostics;

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
		_horizontalDeathZone = (int)(GetViewport().GetVisibleRect().Size.X / 10 /2);
		_verticalDeathZone = (int)(GetViewport().GetVisibleRect().Size.Y / 10 / 2);

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
			_resetInput();
		}
	}

	private void _resetInputHorizontal()
	{
		Input.ActionRelease("ui_left");
		Input.ActionRelease("ui_right");
	}
	private void _resetInputVertical()
	{
		Input.ActionRelease("ui_down");
		Input.ActionRelease("ui_up");
	}

	private void _resetInput()
	{
		_resetInputHorizontal();
		_resetInputVertical();
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);
		if (_isDragging)
		{
			Vector2 currentPosition = GetViewport().GetMousePosition();
			Vector2 movement = currentPosition - _startingPoint;

			Debug.WriteLine($"SP {_startingPoint}");
			Debug.WriteLine($"CP {currentPosition}");
			Debug.WriteLine($"M {movement}");

			if (movement.X > _horizontalDeathZone)
			{
				Input.ActionRelease("ui_left");
				Input.ActionPress("ui_right", 1);
			}
			else if (movement.X < -_horizontalDeathZone)
			{
				Input.ActionRelease("ui_right");
				Input.ActionPress("ui_left", 1);
			}
			else
			{
				_resetInputHorizontal();
			}

			if (movement.Y > _verticalDeathZone)
			{
				Input.ActionRelease("ui_up");
				Input.ActionPress("ui_down", 1);
			}
			else if (movement.Y < -_verticalDeathZone)
			{
				Input.ActionRelease("ui_down");
				Input.ActionPress("ui_up", 1);
			}
			else
			{
				_resetInputVertical();
			}
		}
	}
}