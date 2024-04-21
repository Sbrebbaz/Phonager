using Godot;

public class SaveModel
{
	private int _record = 0;

	public int Record
	{
		get { return _record; }
		set { _record = value; }
	}

	public SaveModel() { }

	public SaveModel(int record)
	{
		_record = record;
	}
}