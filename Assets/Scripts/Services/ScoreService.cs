public class ScoreService {

	private int score;
	private const string TEXT_SCORE = "Score: ";

	public ScoreService ()
	{
		this.Score = 0;
	}
	
	public int Score {
		get {
			return this.score;
		}
		set {
			score = value;
		}
	}

	public string getTextScore(){

		return TEXT_SCORE + Score;
	}

}
