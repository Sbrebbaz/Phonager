using static Phonager.Enumerators;

namespace Phonager
{
	public interface ISaveManager
	{
		public void LoadFile();
		public void SaveFile();
		public SaveModel GetSaveData();
	}
}
