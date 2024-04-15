using static Phonager.Enumerators;

namespace Phonager
{
	public interface IMatchManager
	{
		public void StartMatch();
		public void EndMatch();

		public void SetCurrentPoints(int points);
		public void IncrementPoints();
		public int GetCurrentPoints();
		public void ResetPoints();

		public void InvertDifficulty();
		public void SetCurrentDifficultyMultiplier(double difficultyMultiplier);
		public void IncrementDifficultyMultiplier();
		public void ResetCurrentDifficultyMultiplier();
		public double GetCurrentDifficultyMultiplier();
	}
}
