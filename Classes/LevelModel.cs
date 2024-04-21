using Godot;
using static Constants;

[GlobalClass]
public partial class LevelModel : Resource
{
	[Export] public int WallCount { get; set; } = 1;
	[Export] public float WallSpeed { get; set; } = 1f;
	[Export] public bool InvertWallDirection { get; set; } = false;
	[Export] public int TimeBetweenWalls { get; set; } = 1000;
	[Export] public byte WallAlpha { get; set; } = 255;
	[Export] public float PlayerSpeed { get; set; } = 300f;
	[Export] public bool InvertPlayerControls { get; set; } = false;
}