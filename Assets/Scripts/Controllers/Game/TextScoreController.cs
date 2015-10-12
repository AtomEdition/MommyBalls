using UnityEngine;
using System.Collections;

public class TextScoreController : MonoBehaviour {
		
	private const string TEXT_SCORE = "Score : ";	
	private LevelService levelService = Singleton<LevelService>.GetInstance();

	// Use this for initialization
	void Start () {
	
		levelService.OnBallDestroy.eventAttachTo += this.SetText;
		SetText ();
	}
	
	// Update is called once per frame
	private void SetText () {

		SetTextScore ();
		SetColorScore (levelService.GetStarCount ());
	}

	
	public void SetTextScore() {

		string text = TEXT_SCORE + levelService.ScoreCurrent;
		this.GetComponent<TextMesh>().text = text;
	}

	public void SetColorScore(int starsCount) {

		switch (starsCount) {

		case 0:			
			this.GetComponent<TextMesh>().color = Color.black;
			break;

		case 1:
			this.GetComponent<TextMesh>().color = new Color(0.9F, 0.4F, 0F);
			break;

		case 2:
			this.GetComponent<TextMesh>().color = new Color(0.6F, 0.6F, 0.6F);
			break;

		case 3:
			this.GetComponent<TextMesh>().color = new Color(1F, 0.8F, 0F);
			break;
		}
	}
}
