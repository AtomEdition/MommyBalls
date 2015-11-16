using UnityEngine;
using System.Collections;

public class GameCameraController : MonoBehaviour {

	public int[] levelData = new int[4];
	public int levelNumber = 1;

	private LevelService levelService = Singleton<LevelService>.GetInstance();

	// Use this for initialization
	void Start () {

		levelService.BallCount = levelData [0];
		levelService.ScoreStars3 = levelData [1];
		levelService.ScoreStars2 = levelData [2];
		levelService.ScoreStars1 = levelData [3];
		levelService.CurrentLevel = levelNumber;
	}
	
	// Update is called once per frame
	void Update () {
	}

}
