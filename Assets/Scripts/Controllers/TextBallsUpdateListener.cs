﻿using UnityEngine;
using System.Collections;

public class TextBallsUpdateListener : MonoBehaviour {
	
	private const string TEXT_BALLS_COUNT = "Balls : ";
	private LevelService levelService = Singleton<LevelService>.getInstance();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		setTextBallCount ();
	}
	
	private void setTextBallCount() {

		string text = TEXT_BALLS_COUNT + levelService.BallCount;		
		this.GetComponent<GUIText> ().text = text;
	}
}
