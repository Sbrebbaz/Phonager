using Godot;
using Newtonsoft.Json;
using System;
using System.IO;
using static Constants;

public partial class SaveManager : Node, ISaveManager
{
	private SaveModel _saveData;

	public override void _Ready()
	{
		LoadFile();
	}

	public void LoadFile()
	{
		_saveData = new SaveModel();
	}

	public void SaveFile()
	{

	}

	public SaveModel GetSaveData()
	{
		return _saveData;
	}
}