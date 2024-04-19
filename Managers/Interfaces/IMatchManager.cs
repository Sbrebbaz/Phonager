using static Phonager.Enumerators;

namespace Phonager
{
	public interface IMatchManager
	{
		//Match management
		public void StartMatch();
		public void EndMatch();

		public void InvertDifficulty();

		//Points
		public void SetCurrentPoints(int points);
		public void IncrementPoints();
		public int GetCurrentPoints();
		public void ResetPoints();

		//Difficulty / Wall speed
		public void SetCurrentDifficultyMultiplier(double difficultyMultiplier);
		public void IncrementDifficultyMultiplier();
		public void ResetCurrentDifficultyMultiplier();
		public double GetCurrentDifficultyMultiplier();

		//Level counter management
		public void SetLevelCounter(int levelCounter);
		public void IncreaseLevelCounter();
		public void ResetLevelCounter();
		public int GetLevelCounter();

	}
}
