using UnityEngine;
using System.Collections;

public class TextScoreUpdateListener : MonoBehaviour {
		
	private const string TEXT_SCORE = "Score : ";	
	private ScoreService scoreService = Singleton<ScoreService>.getInstance();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		setTextScore ();
	}

	
	public void setTextScore()
	{
		string text = TEXT_SCORE + scoreService.Score;
		this.GetComponent<GUIText>().text = text;
	}
}
