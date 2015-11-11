﻿using UnityEngine;
using System.Collections;

public class PauseButtonController : MonoBehaviour {
	
	public GameObject menuPrefab;
	InputService inputService = Singleton<InputService>.GetInstance();

	// Use this for initialization
	void Start () {

		gameObject.GetComponent<Renderer>().sortingLayerName = "Ui";
	}
	
	// Update is called once per frame
	void Update () {
		
		OnClick ();
	}

	private void OnClick(){
		
		if (inputService.IsInputDown ()) {
			
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);			
			
			if (hit.collider != null && gameObject.Equals (hit.collider.gameObject)) {
				
				GameObject menu = Instantiate(menuPrefab, new Vector2 (), Quaternion.identity) as GameObject;
				gameObject.GetComponent<SpriteRenderer>().enabled = false;				
				gameObject.GetComponent<CircleCollider2D>().enabled = false;
				menu.GetComponentInChildren<ResumeButtonController>().PauseButtonAppearTo = gameObject;
			}
			
		}
	}
}
