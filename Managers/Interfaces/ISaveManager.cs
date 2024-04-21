using static Enumerators;

public interface ISaveManager
{
	public void LoadFile();
	public void SaveFile();
	public SaveModel GetSaveData();
}