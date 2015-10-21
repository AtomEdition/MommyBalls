using UnityEngine;
using System.Collections;

public class LevelService {

	private int ballCount;
	private int scoreCurrent;
	private int scoreStars3;
	private int scoreStars2;
	private int scoreStars1;

	public CustomEvent OnBallCreate = new CustomEvent();
	public CustomEvent OnBallRelease = new CustomEvent();
	public CustomEvent OnBallCatch = new CustomEvent();
	public CustomEvent OnBallGrounded = new CustomEvent();
	public CustomEvent OnBallDestroy = new CustomEvent();

	public LevelService (){
		this.BallCount = 5;
		this.ScoreStars3 = 5;
		this.ScoreStars2 = 3;
		this.ScoreStars1 = 1;

		PrepareForNewLevel ();
	}

	public void PrepareForNewLevel() {

		ScoreCurrent = 0;
		OnBallCreate.RemoveAllEvents ();
		OnBallRelease.RemoveAllEvents ();
		OnBallCatch.RemoveAllEvents ();
		OnBallGrounded.RemoveAllEvents ();
		OnBallDestroy.RemoveAllEvents ();
	}

	public void CheckForLevelEnded() {		
		
		if (BallCount <= 0 
		    && GameObject.FindGameObjectsWithTag(Tags.BALL).Length == 0) {

			Application.LoadLevel (Scenes.LEVEL_COMPLETE);
		}
	}
		

	public int GetStarCount(){
		
		return (ScoreCurrent < ScoreStars3)
			? (ScoreCurrent < ScoreStars2)
				? (ScoreCurrent < ScoreStars1)
				? 0
				: 1
				: 2
				: 3;
	}

	public int BallCount {
		get {
			return this.ballCount;
		}
		set {
			ballCount = value;
		}
	}

	public int ScoreCurrent {
		get {
			return this.scoreCurrent;
		}
		set {
			scoreCurrent = value;
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
