public class InterfaceService {
	
	private LevelService levelService = Singleton<LevelService>.getInstance();
	private ScoreService scoreService = Singleton<ScoreService>.getInstance();

	public string getTextBallCount()
	{		
		return GameUiPreferences.textBallCount + levelService.BallCount;
	}
	
	public string getTextScore()
	{
		return GameUiPreferences.textScore + scoreService.Score;
	}
}