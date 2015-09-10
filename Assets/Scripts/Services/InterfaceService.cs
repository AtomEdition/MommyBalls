public class InterfaceService {
	
	private LevelService levelService = Singleton<LevelService>.getInstance();
	private ScoreService scoreService = Singleton<ScoreService>.getInstance();

	public string getTextBallCount()
	{		
		return InterfaceProperties.TEXT_BALLS_COUNT + levelService.BallCount;
	}
	
	public string getTextScore()
	{
		return InterfaceProperties.TEXT_SCORE + scoreService.Score;
	}
}