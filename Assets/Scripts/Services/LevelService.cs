using UnityEngine;
using System.Collections;

public class LevelService {

	private int ballCount;
	private int scoreStars3;
	private int scoreStars2;
	private int scoreStars1;

	public delegate void MethodContainer();
	public event MethodContainer OnBallCreate;

	public LevelService (){
		this.BallCount = 5;
		this.ScoreStars3 = 5;
		this.ScoreStars2 = 3;
		this.ScoreStars1 = 1;
	}

	public LevelService (int ballCount, int scoreStars3, int scoreStars2, int scoreStars1)
	{
		this.BallCount = ballCount;
		this.ScoreStars3 = scoreStars3;
		this.ScoreStars2 = scoreStars2;
		this.ScoreStars1 = scoreStars1;
	}

	public void CreateEventForBallCreated() {

		OnBallCreate ();
	}

	public void CheckForLevelEnded() {		
		
		if (BallCount <= 0 
		    && GameObject.FindGameObjectsWithTag(Tags.BALL).Length == 0) {
			
			Application.LoadLevel (ScoreProperties.SCREEN_NAME_LEVEL_COMPLETE);
		}
	}
	
	public int BallCount {
		get {
			return this.ballCount;
		}
		set {
			ballCount = value;
		}
	}
	
	public int ScoreStars3 {
		get {
			return this.scoreStars3;
		}
		set {
			scoreStars3 = value;
		}
	}
	
	public int ScoreStars2 {
		get {
			return this.scoreStars2;
		}
		set {
			scoreStars2 = value;
		}
	}
	
	public int ScoreStars1 {
		get {
			return this.scoreStars1;
		}
		set {
			scoreStars1 = value;
		}
	}
	
}
