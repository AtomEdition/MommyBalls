using UnityEngine;
using System.Collections;

public class TextScoreUpdateListener : MonoBehaviour {
		
	private const string TEXT_SCORE = "Score : ";	
	private LevelService levelService = Singleton<LevelService>.GetInstance();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		setTextScore ();
	}

	
	public void setTextScore() {

		string text = TEXT_SCORE + levelService.ScoreCurrent;
		this.GetComponent<GUIText>().text = text;
	}
}
