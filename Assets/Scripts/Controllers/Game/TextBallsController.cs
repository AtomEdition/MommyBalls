using UnityEngine;
using System.Collections;

public class TextBallsController : MonoBehaviour {
	
	private const string TEXT_BALLS_COUNT = "Balls : ";
	private LevelService levelService = Singleton<LevelService>.GetInstance();

	// Use this for initialization
	void Start () {
	
		levelService.OnBallCreate.eventAttachTo += this.SetTextBallCount;
		SetTextBallCount ();
	}
	
	private void SetTextBallCount() {

		string text = TEXT_BALLS_COUNT + levelService.BallCount;		
		this.GetComponent<TextMesh> ().text = text;
	}
}
