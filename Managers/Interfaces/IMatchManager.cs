using static Enumerators;

public interface IMatchManager
{
	//Match management
	public void StartMatch();
	public void PlayLevel(LevelModel levelToPlay);
	public void EndMatch();

	//Points
	public void SetCurrentPoints(int points);
	public void IncrementPoints();
	public int GetCurrentPoints();
	public void ResetPoints();
}