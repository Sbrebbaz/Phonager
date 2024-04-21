public interface IWallManager
{
	public void SetCurrentWallSpeed(float speed);
	public float GetCurrentWallSpeed();
	public void ResetWallSpeed();
	public void InvertWallSpeed();
	public void GenerateRandomWall();
	public void RefreshCurrentLevel();
}