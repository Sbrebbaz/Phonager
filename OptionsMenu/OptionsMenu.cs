using Godot;
using System;

namespace Phonager
{
	public partial class OptionsMenu : CanvasLayer
	{
		private GameManager _gameManager;

		public override void _Ready()
		{
			_gameManager = GetNode<GameManager>("/root/GameManager");
		}

		public void _on_button_pressed()
		{
			_gameManager.LoadScene(Enumerators.GameScenes.Menu);

		}
	}
}