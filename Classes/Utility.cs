using System;
using System.IO;
using Godot;

namespace Phonager
{
	public static class Utility
	{
		public static Color GetRandomColor()
		{
			byte[] bytes = new byte[3];
			new Random().NextBytes(bytes);

			return Color.Color8(bytes[0], bytes[1], bytes[2]);
		}
	}
}
