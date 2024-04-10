using Godot;
using System;

public partial class WallDestroyer : Area2D
{
	public void _on_area_entered(Area2D area)
	{
		area.GetParent().QueueFree();
	}
}
