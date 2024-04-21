using static Enumerators;

public interface IPlayerManager
{
	public void SetCurrentPlayerSpeed(float speed);
	public float GetCurrentPlayerSpeed();
	public void ResetPlayerSpeed();
	public void InvertPlayerSpeed();
}