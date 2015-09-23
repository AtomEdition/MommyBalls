﻿using UnityEngine;
using System.Collections;

public class MommyController : MonoBehaviour {

	private ScoreService scoreService = Singleton<ScoreService>.GetInstance();

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator OnCollisionEnter2D(Collision2D collision){

		if (collision.gameObject.tag == "Ball") {

			collision.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			yield return new WaitForSeconds(0.05F);
			Destroy (collision.gameObject);

			scoreService.Score++;			
		}
	}
}
