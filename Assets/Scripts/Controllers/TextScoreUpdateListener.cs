using UnityEngine;
using System.Collections;

public class TextScoreUpdateListener : MonoBehaviour {

	ScoreService scoreService = Singleton<ScoreService>.getInstance();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		this.GetComponent<GUIText>().text = scoreService.getTextScore ();
	}
}
