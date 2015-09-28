using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public int[] levelData = new int[4];

	private LevelService levelService = Singleton<LevelService>.GetInstance();

	// Use this for initialization
	void Start () {

		levelService.BallCount = levelData [0];
		levelService.ScoreStars3 = levelData [1];
		levelService.ScoreStars2 = levelData [2];
		levelService.ScoreStars1 = levelData [3];
	}
	
	// Update is called once per frame
	void Update () {
	}

}
