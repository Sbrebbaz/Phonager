using Godot;

namespace Phonager
{
	[GlobalClass]
	public partial class LevelModel : Resource
	{
		public int WallCount { get; set; } = 1;
		public float WallSpeed { get; set; }
		public byte WallAlpha { get; set; }
		public bool InvertWallDirection { get; set; }
		public int TimeBetweenWalls { get; set; } = 1000;

		public float PlayerSpeed {  get; set; }
		public bool InvertPlayerControls { get; set; }
	}
}
